using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using dev.jerry_h.pc_tools.CommonLibrary;
using dev.jerry_h.pc_tools.AndroidLibrary;

namespace dev.jerry_h.pc_tools.InstructionLibrary
{
    public class clsCommand
    {
        private clsScriptLine scriptline = null;
        private readonly String originalString ="";
        private String processedString = "";
        private String saveResultToVariableName = "";
        private Object commandRunner = null;
        private MethodInfo method = null;
        private List<Object> parameters = new List<Object>();
        private List<clsCommand> subCommands = new List<clsCommand>();
        
        #region For special-symbols pair
        private List<clsSpecialSymbolsPair> quotationMarkPairs = new List<clsSpecialSymbolsPair>();
        private List<clsSpecialSymbolsPair> percentSignPairs = new List<clsSpecialSymbolsPair>();
        private List<clsSpecialSymbolsPair> parenthesisPairs = new List<clsSpecialSymbolsPair>();
        #endregion For special-symbols pair

        #region for special characters of operation
        List<clsOperandString> Operands = new List<clsOperandString>();
        List<clsOperationString> Operations = new List<clsOperationString>();
        #endregion for special characters of operation

        public clsCommand(clsScriptLine scriptline, String commandString) : this(scriptline, commandString, clsVariables.KEY_CommonReturnValue) { }
        public clsCommand(clsScriptLine scriptline,String commandString,String saveResultToVariableName) // Object commandRunner,MethodInfo method,object[] parameters)
        {
            this.scriptline = scriptline;
            this.originalString = commandString;
            this.saveResultToVariableName = saveResultToVariableName;
        }

        public bool Compiler()
        {
            bool bResult = true;
            commandRunner = null;
            MethodInfo method = null;
            processedString = originalString;
            bResult &= findSpecialSymbolsPairs(processedString);
            bResult &= checkVariablesInPercentSignPairExist();
            if (bResult)
            {
                #region Functions
                if (parenthesisPairs.Count > 0 && parenthesisPairs.Last().LeftIndex > 0 && 
                    (parenthesisPairs.Last().RightIndex == processedString.Length - 1) &&
                    (processedString.Substring(0, parenthesisPairs.Last().LeftIndex).Split(clsOperationString.OperationSymbols,StringSplitOptions.None).Count()==1)
                   )
                {
                    #region parse command header
                    String cmdTemp = processedString.Substring(0, parenthesisPairs.Last().LeftIndex).Trim();
                    String deviceName = "", componentName = "", methodName = "";
                    bResult &= getCommandHeader(cmdTemp, ref deviceName, ref componentName, ref methodName);
                    if (scriptline.Script.Package.Devices.ContainsKey(deviceName))
                    {
                        if (deviceName.StartsWith(clsPackage.KEY_Device))
                        {
                            IDevice aDevice = (IDevice)scriptline.Script.Package.Devices[deviceName];
                            IDeviceComponent aDevComp = null;
                            if (componentName != null && componentName.Length > 0)
                            {
                                aDevComp = (IDeviceComponent)aDevice.DeviceComponents[componentName];
                            } if (aDevComp != null)
                            {
                                commandRunner = aDevComp;
                            }
                            else
                            {
                                bResult = false;
                            }
                        }
                        else  //External components
                        {

                        }
                    }
                    else if (deviceName.Equals(clsPackage.KEY_BasicOperation))
                    {
                        commandRunner = new clsBasicOperations();
                    }
                    else
                    {
                        bResult = false;
                        scriptline.Script.RuntimeErrorMessages.Add(new clsRuntimeErrorMessage(scriptline.LineNumber, deviceName + " does not exist."));
                    }
                    #endregion parse command header

                    #region parse parameters of command
                    int start = parenthesisPairs.Last().LeftIndex;
                    int length = parenthesisPairs.Last().RightIndex - start;
                    String paramsTemp = processedString.Substring(start, length).TrimStart(new char[] { '(' }).TrimEnd(new char[] { ')' });
                    bResult &= getParametersOfMethod(start, paramsTemp);
                    #endregion parse parameters of command
                    
                    if (bResult)
                    {
                        method = ((IDeviceComponent)commandRunner).GetMethod(methodName,parameters.ToArray());
                        if (method == null)
                        {
                            bResult = false;
                            scriptline.Script.RuntimeErrorMessages.Add(new clsRuntimeErrorMessage(scriptline.LineNumber, methodName + "(params[" + parameters.Count + "]), does not exist."));
                        }
                    }
                }
                #endregion Functions
                #region Operations
                #region Opertaions in parenthesisPairs is the first priority
                else if (parenthesisPairs.Count > 0)
                {
                    for (int i = parenthesisPairs.Count - 1; i >= 0;i--)
                    {
                        if (parenthesisPairs[i].Text.Length > 0)
                        {
                            String strTempVariable = scriptline.Script.GetNewTempVariableName;
                            clsCommand subOperation = new clsCommand(scriptline, parenthesisPairs[i].Text, strTempVariable);
                            subCommands.Add(subOperation);
                            processedString = replaceSubString(processedString, "%"+strTempVariable+"%", parenthesisPairs[i].LeftIndex, parenthesisPairs[i].RightIndex);
                        }                       
                    }
                }
                #endregion Opertaions in parenthesisPairs is the first priority
                bResult &= compilerOperandsAndOperations();
                if (bResult)
                {
                    commandRunner = scriptline.Script.Package.BasicOperations;
                }
                #endregion Operations

                //#region Assignment

                //#endregion Assignment
            }
            foreach (clsCommand subCommand in subCommands)
            {
                bResult &= subCommand.Compiler();
            }
            return bResult;
        }

        public object Run()
        {
            object rtnValue = null;
            foreach (clsCommand cmd in subCommands)
            {
                cmd.Run();
            }
            if (method == null && parameters.Count == 1)
            {
                rtnValue = replaceVariableToValue(parameters[0].ToString());
            }
            else
            {
                for (int i=0;i<parameters.Count;i++)
                {
                    parameters[i] = replaceVariableToValue(parameters[i].ToString());
                }
                rtnValue = method.Invoke(commandRunner, parameters.ToArray());
            }
            scriptline.Script.SetVariable(saveResultToVariableName, rtnValue);
            return rtnValue;
        }

        private bool checkVariablesInPercentSignPairExist()
        {
            bool bResult = true,bTemp =false;;
            for(int index=0; index<percentSignPairs.Count;index++)
            {
                bTemp = scriptline.Script.IsVariableExist(percentSignPairs[index].Text);
                if(!bTemp)
                {
                    addRuntimeErrorMessages("Variable name \""+percentSignPairs[index].Text+"\" does not exist.");
                }
                bResult&=bTemp;
            }
            return bResult;
        }

        private String replaceSubString(String source, String newStr, int startIndex, int endIndex)
        {
            String result = "";
            if (endIndex > startIndex && startIndex >= 0)
            {
                result = source.Substring(0, startIndex);
                result += newStr;
                if(source.Length>(endIndex+1))
                {
                    result+=source.Substring(endIndex+1);
                }
            }
            else
            {
                result = source;
            }
            return result;
        }

        private String replaceVariableToValue(String inputStr)
        {
            String strResult = inputStr;
            List<clsSpecialSymbolsPair> variableString = new List<clsSpecialSymbolsPair>();
            if (findPercentSignPairs(inputStr, ref variableString))
            {
                for (int i = variableString.Count - 1; i >= 0; i--)
                {
                    if(scriptline.Script.IsVariableExist(variableString[i].Text))
                    {
                        strResult = inputStr.Replace("%" + variableString[i].Text + "%", scriptline.Script.FindVariable(variableString[i].Text).ToString());
                    }
                }
            }
            else
            {
                addRuntimeErrorMessages("Fail to parse variable\"" + inputStr + "\"");
            }
            return strResult;
        }

        private bool getCommandHeader(String inputStr, ref String device, ref String component, ref String method)
        {
            bool result = true;
            try
            {
                String[] subCmd = inputStr.Split(new char[] { '.' });
                switch (subCmd.Length)
                {
                    case 3:
                        device = subCmd[0];
                        component = subCmd[1];
                        method = subCmd[2];
                        break;
                    case 2:
                        device = subCmd[0];
                        component = subCmd[0];
                        method = subCmd[1];
                        break;
                    case 1:
                        device = clsPackage.KEY_BasicOperation;
                        component = clsPackage.KEY_BasicOperation;
                        method = subCmd[0];
                        break;
                    default:
                        //Unknow command, add compiler error message here
                        result = false;
                        addRuntimeErrorMessages("Unknow command \"" + inputStr + "\"");
                        break;
                }
            }
            catch
            {
                result = false;
                addRuntimeErrorMessages("Parse command error : \"" + inputStr + "\"");
            }
            return result;
        }

        private bool getParametersOfMethod(int offsetIndex, String paramString)
        {
            bool bIsParsedOK = true;
            int previousIndex = 0, parsedIndex = 0;
            if (parameters != null)
            {
                parameters.Clear();
                parameters = null;
            }
            parameters = new List<object>();
            bool bSkipFlag = false;
            while (paramString.Substring(parsedIndex).Contains(','))
            {
                parsedIndex = paramString.IndexOf(',', parsedIndex);
                if (parsedIndex == 0)
                {
                    bIsParsedOK = false;
                    addRuntimeErrorMessages("Syntax error in parameters, the symbol\",\" could not be the first character.");
                    break;
                }
                else
                {
                    bSkipFlag = false;
                    foreach (clsSpecialSymbolsPair sp in quotationMarkPairs)
                    {
                        if (parsedIndex > offsetIndex + sp.LeftIndex && offsetIndex + parsedIndex < sp.RightIndex)
                        {
                            bSkipFlag = true;
                            break; // Skip the comma symbol in the QuotationMarks
                        }
                    }
                    if (!bSkipFlag)
                    {
                        String param = paramString.Substring(previousIndex, parsedIndex - previousIndex);
                        parameters.Add(param);
                        previousIndex = parsedIndex + 1;
                    }
                    parsedIndex++;
                }
            }
            parameters.Add(paramString.Substring(previousIndex, paramString.Length - previousIndex)); //Add last one into parameters list
            return bIsParsedOK;
        }
        
        #region findSpecialSymbolsPairs
        private bool findSpecialSymbolsPairs(String inputStr)
        {
            return findQuotationMarkPairs(inputStr,ref quotationMarkPairs) &&
                   findPercentSignPairs(inputStr,ref percentSignPairs) &&
                   findParenthesisPairs(inputStr, ref parenthesisPairs, quotationMarkPairs);
        }

        private bool findQuotationMarkPairs(String inputStr,ref List<clsSpecialSymbolsPair> lstSymbolsPair)
        {
            bool result = true;
            int parsedIndex = 0;
            lstSymbolsPair.Clear();
            List<int> lstFoundIndex = new List<int>();
            String strTemp = inputStr;
            while (strTemp.Substring(parsedIndex).Contains("\""))
            {
                int tempIndex = strTemp.IndexOf("\"", parsedIndex);
                if (tempIndex == 0)
                {
                    lstFoundIndex.Add(0);
                }
                else
                {
                    if (strTemp[tempIndex - 1] != '\\') //Skip the special symbols just following after the ESCAPER
                    {
                        lstFoundIndex.Add(tempIndex);
                    }
                }
                parsedIndex = tempIndex + 1;
            }
            if (lstFoundIndex.Count > 0)
            {
                if (lstFoundIndex.Count % 2 == 0)
                {
                    while (lstFoundIndex.Count > 0)
                    {
                        int end = lstFoundIndex[1];
                        int start = lstFoundIndex[0];
                        String containingStr = "";
                        if (end > (start + 1))
                        {
                            containingStr = inputStr.Substring(start + 1, end - (start + 1));
                        }
                        lstSymbolsPair.Add(new clsSpecialSymbolsPair(start, end, containingStr));
                        lstFoundIndex.RemoveAt(1);
                        lstFoundIndex.RemoveAt(0);
                    }
                }
                else
                {
                    result = false;
                    addRuntimeErrorMessages("Expect one more \" here.");
                }
            }
            return result;
        }

        private bool findPercentSignPairs(String inputStr, ref List<clsSpecialSymbolsPair> lstSymbolsPair)
        {
            bool result = true;
            int parsedIndex = 0;
            List<int> lstFoundIndex = new List<int>();
            lstSymbolsPair.Clear();
            String strTemp = inputStr;
            while (strTemp.Substring(parsedIndex).Contains("%"))
            {
                int tempIndex = strTemp.IndexOf("%", parsedIndex);
                if (tempIndex == 0)
                {
                    lstFoundIndex.Add(0);
                }
                else
                {
                    if (strTemp[tempIndex - 1] != '\\') //Skip the special symbols just following after the ESCAPER
                    {
                        lstFoundIndex.Add(tempIndex);
                    }
                }
                parsedIndex = tempIndex + 1;
            }
            if (lstFoundIndex.Count > 0)
            {
                if (lstFoundIndex.Count % 2 == 0)
                {
                    while (lstFoundIndex.Count > 0)
                    {
                        int end = lstFoundIndex[1];
                        int start = lstFoundIndex[0];
                        String containingStr = "";
                        if (end > (start + 1))
                        {
                            containingStr = inputStr.Substring(start + 1, end - (start + 1));
                        }
                        lstSymbolsPair.Add(new clsSpecialSymbolsPair(start, end, containingStr));
                        lstFoundIndex.RemoveAt(1);
                        lstFoundIndex.RemoveAt(0);
                    }
                }
                else
                {
                    result = false;
                    addRuntimeErrorMessages("Expect one more % here.");
                }
            }
            return result;
        }

        private bool findParenthesisPairs(String inputStr, ref List<clsSpecialSymbolsPair> lstSymbolsPair, List<clsSpecialSymbolsPair>  quotationPairs)
        {
            bool result = true;
            bool bSkipFlag = false; // If Parenthesis locate between the QuotationMarks, just seem it as a string.
            lstSymbolsPair.Clear();
            Stack<int> stkFoundLeftParenthesisIndex = new Stack<int>();
            String strTemp = inputStr;
            for (int tempIndex = 0; tempIndex < strTemp.Length; tempIndex++)
            {
                #region If Parenthesis locate between the QuotationMarks, just seem it as a string.
                bSkipFlag = false;
                foreach (clsSpecialSymbolsPair sPair in quotationPairs)
                {
                    if (tempIndex > sPair.LeftIndex && tempIndex < sPair.RightIndex)
                    {
                        bSkipFlag = true;
                        break;
                    }
                }
                if (bSkipFlag)
                {
                    continue;
                }
                #endregion If Parenthesis locate between the QuotationMarks, just seem it as a string.
                if (strTemp[tempIndex] == '(')
                {
                    if (tempIndex == 0)
                    {
                        stkFoundLeftParenthesisIndex.Push(0);
                    }
                    else
                    {
                        if (strTemp[tempIndex - 1] != '\\') //Skip the special symbols just following after the ESCAPER
                        {
                            stkFoundLeftParenthesisIndex.Push(tempIndex);
                        }
                    }
                }
                else if (strTemp[tempIndex] == ')')
                {
                    if (tempIndex == 0)
                    {
                        result = false;
                        addRuntimeErrorMessages("Expect one more \"(\" here.");
                    }
                    else
                    {
                        if (strTemp[tempIndex - 1] != '\\') //Skip the special symbols just following after the ESCAPER
                        {
                            if (stkFoundLeftParenthesisIndex.Count > 0)
                            {
                                int start = stkFoundLeftParenthesisIndex.Pop();
                                if (stkFoundLeftParenthesisIndex.Count == 0)  //Just add first level of parentthsis pair into the list
                                {
                                    String containingStr = "";
                                    if (tempIndex > (start + 1))
                                    {
                                        containingStr = inputStr.Substring(start + 1, tempIndex - (start + 1));
                                    }
                                    lstSymbolsPair.Add(new clsSpecialSymbolsPair(start, tempIndex, containingStr));
                                }
                            }
                            else
                            {
                                result = false;
                                addRuntimeErrorMessages("Expect one more \"(\" here.");
                            }
                        }
                    }
                }
            }
            if (stkFoundLeftParenthesisIndex.Count > 0)
            {
                result = false;
                addRuntimeErrorMessages("Expect one more \")\" here.");
            }
            return result;
        }
        #endregion findSpecialSymbolsPairs
        
        private void addRuntimeErrorMessages(String msg)
        {
            scriptline.Script.RuntimeErrorMessages.Add(new clsRuntimeErrorMessage(scriptline.LineNumber, msg));
        }

        #region for Operation compiler
        private bool getOperandsAndOperations(String inputStr)
        {
            bool bResult = true;
            bool bSkipContinuously = false;
            bool bSkipOnce = false;
            int processedIndex = 0;
            Operands.Clear();
            Operations.Clear();
            try
            {
                for (int index = 0; index < inputStr.Length; index++)
                {
                    if (inputStr[index].Equals("\"") && !inputStr[index - 1].Equals("\\")) //Skip any symbols in the string object
                    {
                        bSkipContinuously = !bSkipContinuously;
                    }
                    if (bSkipContinuously)
                    {
                        continue;
                    }
                    if (bSkipOnce) //Skip next character
                    {
                        bSkipOnce = false;
                        continue;
                    }
                    #region Operation"*"
                    if (inputStr[index].Equals('*'))
                    {
                        clsOperandString operand = new clsOperandString(inputStr.Substring(processedIndex, index-processedIndex), processedIndex);
                        Operands.Add(operand);
                        clsOperationString operation = new clsOperationString("*", index);
                        processedIndex = index + operation.Text.Length;
                        Operations.Add(operation);
                    }
                    #endregion Operation"*"
                    #region Operation"/"
                    if (inputStr[index].Equals('/'))
                    {
                        clsOperandString operand = new clsOperandString(inputStr.Substring(processedIndex, index - processedIndex), processedIndex);
                        Operands.Add(operand);
                        clsOperationString operation = new clsOperationString("/", index);
                        processedIndex = index + operation.Text.Length;
                        Operations.Add(operation);
                    }
                    #endregion Operation"/"
                    #region Operation"\%"
                    if (inputStr[index].Equals('\\'))
                    {
                        if ((inputStr.Length > index + 1) && inputStr[index + 1].Equals('%'))
                        {
                            bSkipOnce = true;
                            clsOperandString operand = new clsOperandString(inputStr.Substring(processedIndex, index - processedIndex), processedIndex);
                            Operands.Add(operand);
                            clsOperationString operation = new clsOperationString("\\%", index);
                            processedIndex = index + operation.Text.Length;
                            Operations.Add(operation);
                        }
                        else
                        {
                            bResult = false;
                            addRuntimeErrorMessages("Unknow operation \"\\\"");
                        }
                    }
                    #endregion Operation"\%"
                    #region Operation"+"
                    if (inputStr[index].Equals('+'))
                    {
                        clsOperandString operand = new clsOperandString(inputStr.Substring(processedIndex, index - processedIndex), processedIndex);
                        Operands.Add(operand);
                        clsOperationString operation = new clsOperationString("+", index);
                        processedIndex = index + operation.Text.Length;
                        Operations.Add(operation);
                    }
                    #endregion Operation"+"
                    #region Operation"-"
                    if (inputStr[index].Equals('-'))
                    {
                        clsOperandString operand = new clsOperandString(inputStr.Substring(processedIndex, index - processedIndex), processedIndex);
                        Operands.Add(operand);
                        clsOperationString operation = new clsOperationString("-", index);
                        processedIndex = index + operation.Text.Length;
                        Operations.Add(operation);
                    }
                    #endregion Operation"-"
                    #region Operation"=="
                    if (inputStr[index].Equals('='))
                    {
                        if ((inputStr.Length > index + 1) && inputStr[index + 1].Equals('='))
                        {
                            bSkipOnce = true;
                            clsOperandString operand = new clsOperandString(inputStr.Substring(processedIndex, index - processedIndex), processedIndex);
                            Operands.Add(operand);
                            clsOperationString operation = new clsOperationString("==", index);
                            processedIndex = index + operation.Text.Length;
                            Operations.Add(operation);
                        }
                        else
                        {
                            bResult = false;
                            addRuntimeErrorMessages("Unknow operation \"=\"");
                        }

                    }
                    #endregion Operation"=="
                    #region Operation">=" or ">"
                    if (inputStr[index].Equals('>'))
                    {
                        if ((inputStr.Length > index + 1) && inputStr[index + 1].Equals('='))
                        {
                            bSkipOnce = true;
                            clsOperandString operand = new clsOperandString(inputStr.Substring(processedIndex, index), index - processedIndex);
                            Operands.Add(operand);
                            clsOperationString operation = new clsOperationString(">=", index);
                            processedIndex = index + operation.Text.Length;
                            Operations.Add(operation);
                        }
                        else
                        {
                            clsOperandString operand = new clsOperandString(inputStr.Substring(processedIndex, index), index - processedIndex);
                            Operands.Add(operand);
                            clsOperationString operation = new clsOperationString(">", index);
                            processedIndex = index + operation.Text.Length;
                            Operations.Add(operation);
                        }

                    }
                    #endregion Operation">=" or ">"
                    #region Operation">=" or ">"
                    if (inputStr[index].Equals('<'))
                    {
                        if ((inputStr.Length > index + 1) && inputStr[index + 1].Equals('='))
                        {
                            bSkipOnce = true;
                            clsOperandString operand = new clsOperandString(inputStr.Substring(processedIndex, index), processedIndex);
                            Operands.Add(operand);
                            clsOperationString operation = new clsOperationString("<=", index);
                            processedIndex = index + operation.Text.Length;
                            Operations.Add(operation);
                        }
                        else
                        {
                            clsOperandString operand = new clsOperandString(inputStr.Substring(processedIndex, index), processedIndex);
                            Operands.Add(operand);
                            clsOperationString operation = new clsOperationString("<", index);
                            processedIndex = index + operation.Text.Length;
                            Operations.Add(operation);
                        }
                    }
                    #endregion Operation"<=" or "<"
                    #region Operation"!="
                    if (inputStr[index].Equals('!'))
                    {
                        if ((inputStr.Length > index + 1) && inputStr[index + 1].Equals('='))
                        {
                            bSkipOnce = true;
                            clsOperandString operand = new clsOperandString(inputStr.Substring(processedIndex, index), processedIndex);
                            Operands.Add(operand);
                            clsOperationString operation = new clsOperationString("!=", index);
                            processedIndex = index + operation.Text.Length;
                            Operations.Add(operation);
                        }
                        else
                        {
                            bResult = false;
                            addRuntimeErrorMessages("Unknow operation \"!\"");
                        }

                    }
                    #endregion Operation"!="
                }
                clsOperandString operandEnd = new clsOperandString(inputStr.Substring(processedIndex), processedIndex);
                Operands.Add(operandEnd);
            }
            catch(Exception ex)
            {
                bResult = false;
                addRuntimeErrorMessages("Undefinded error, message =" +ex.Message);
            }
            return bResult;
        }

        private bool compilerOperandsAndOperations()
        {
            bool bResult = true;
            bResult &= getOperandsAndOperations(processedString);
            if (bResult && Operands.Count > 0 && Operations.Count > 0)
            {
                if (Operands.Count == Operations.Count + 1)
                {
                    #region last one operation
                    if (Operations.Count == 1)
                    {
                        switch (Operations[0].Text)
                        {
                            case "&":
                                method = getBasicOperationMethodInfo("AND", 2);
                                break;
                            case "|":
                                method = getBasicOperationMethodInfo("OR", 2);
                                break;
                            case "*":
                                method = getBasicOperationMethodInfo("MUL", 2);
                                break;
                            case "/":
                                method = getBasicOperationMethodInfo("DIV", 2);
                                break;
                            case "\\%":
                                method = getBasicOperationMethodInfo("MOD", 2);
                                break;
                            case "+":
                                method = getBasicOperationMethodInfo("ADD", 2);
                                break;
                            case "-":
                                method = getBasicOperationMethodInfo("SUB", 2);
                                break;
                            case "==":
                                method = getBasicOperationMethodInfo("EQUALS", 2);
                                break;
                            case "!=":
                                method = getBasicOperationMethodInfo("NOT_EQUALS", 2);
                                break;
                            case ">=":
                                method = getBasicOperationMethodInfo("GREATER_EQUAL_THAN", 2);
                                break;
                            case "<=":
                                method = getBasicOperationMethodInfo("LESS_EQUAL_THAN", 2);
                                break;
                            case "<":
                                method = getBasicOperationMethodInfo("LESS_THAN", 2);
                                break;
                            case ">":
                                method = getBasicOperationMethodInfo("GREATER_THAN", 2);
                                break;
                            default:
                                method = null;
                                break;
                        }
                        if (method == null)
                        {
                            bResult = false;
                            addRuntimeErrorMessages("Unkonw operatsion \"" + Operations[0].Text + "\"");
                        }
                        parameters.Add(Operands[0]);
                        parameters.Add(Operands[1]);
                    }
                    #endregion last one operation
                    else
                    {
                        int iNextOperationIndex = -1;
                        int iFirstPriorityIndex = -1;
                        int iSecondPriorityIndex = -1;
                        int iThirdPriorityIndex = -1;
                        int iLastPriorityIndex = -1;
                        for (int i = 0; i < Operations.Count; i++)
                        {
                            switch (Operations[i].Text)
                            {
                                case "&":
                                case "|":
                                    if (iFirstPriorityIndex < 0)
                                    {
                                        iFirstPriorityIndex = i;
                                    }
                                    break;
                                case "*":
                                case "/":
                                case "\\%":
                                    if (iSecondPriorityIndex < 0)
                                    {
                                        iSecondPriorityIndex = i;
                                    }
                                    break;
                                case "+":
                                case "-":
                                    if (iThirdPriorityIndex < 0)
                                    {
                                        iThirdPriorityIndex = i;
                                    }
                                    break;
                                case "==":
                                case ">=":
                                case "<=":
                                case "!=":
                                case ">":
                                case "<":
                                    if (iLastPriorityIndex < 0)
                                    {
                                        iLastPriorityIndex = i;
                                    }
                                    break;

                            }
                            if (iFirstPriorityIndex >= 0)
                            {
                                break;
                            }
                        }
                        if (iFirstPriorityIndex >= 0)
                        {
                            iNextOperationIndex = iFirstPriorityIndex;
                        }
                        else if (iSecondPriorityIndex >= 0)
                        {
                            iNextOperationIndex = iSecondPriorityIndex;
                        }
                        else if (iThirdPriorityIndex >= 0)
                        {
                            iNextOperationIndex = iThirdPriorityIndex;
                        }
                        else
                        {
                            iNextOperationIndex = iLastPriorityIndex;
                        }
                        if (iNextOperationIndex >= 0)
                        {
                            String tempCmd = Operands[iNextOperationIndex].Text + Operations[iNextOperationIndex].Text + Operands[iNextOperationIndex + 1].Text;
                            String tempVariable = scriptline.Script.GetNewTempVariableName;
                            clsCommand subCmd = new clsCommand(scriptline, tempCmd, tempVariable);
                            subCommands.Add(subCmd);
                            processedString = processedString.Replace(tempCmd, "%" + tempVariable + "%");
                            bResult &= compilerOperandsAndOperations();
                        }
                        else
                        {
                            bResult = false;
                            addRuntimeErrorMessages("Invaliable operation express");
                        }
                    }
                }
                else
                {
                    bResult = false;
                    addRuntimeErrorMessages("Invaliable operation express");
                }
            }
            else if (Operations.Count == 0 && Operands.Count==1)// Just an assignment
            {
                parameters.Add(Operands[0].Text);
            }
            return bResult;
        }    

        private MethodInfo getBasicOperationMethodInfo(String name, int parametersNumber)
        {
            List<Type> types = new List<Type>();
            for (int index = 0; index < parametersNumber; index++)
            {
                types.Add(typeof(Object));
            }
            MethodInfo mi = scriptline.Script.Package.BasicOperations.GetMethod(name, types.ToArray());
            //scriptline.Script.Package.BasicOperations.GetType().GetMethod(name, types.ToArray());
            return mi;
        }
        #endregion for Operation compiler
    }
}
