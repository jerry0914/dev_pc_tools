using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using dev.jerry_h.pc_tools.AndroidLibrary;
using dev.jerry_h.pc_tools.CommonLibrary;

namespace dev.jerry_h.pc_tools.InstructionLibrary
{
    public class clsScriptLine:IScriptUnit
    {
        public static char ESCAPE_CHARACTER = '\\';
        public int LineNumber
        {
            get
            {
                return lineIndex + 1;
            }
        }
        private int lineIndex = 0;
        private String originalString = "";
        public String OrignalString
        {
            get
            {
                return originalString;
            }
        }

        public String LeftStatement
        {
            get
            {
                return leftStatement;
            }
        }
        private String leftStatement = "";
        public String RightStatement
        {
            get
            {
                return rightStatement;
            }
        }
        private String rightStatement = "";
        public String Remark
        {
            get
            {
                return remark;
            }
        }
        private String remark = "";
        internal clsCommand Command;
        private clsScript script = null;
        /// <summary>
        /// The parent of ScriptLine
        /// </summary>
        public clsScript Script
        {
            get
            {
                return script;
            }
        }
        /// <summary>
        /// ScriptLine doesn't allow to contain sub-units, it should always be empty
        /// </summary>
        public List<IScriptUnit> Units
        {
            get
            {
                return new List<IScriptUnit>();
            }
        }
        public clsScriptLine(clsScript script,int lineIndex, String orignalString)
        {
            this.script = script;
            this.lineIndex = lineIndex;
            this.originalString = orignalString;
        }
        
        public bool Compiler()
        {
            bool isOK = false;
            bool isLeftStatementOK = true;
            bool isRightStatementOK = true;

            String saveResultToVariableName = "";
            spilteString();
            #region Left Statement
            if (leftStatement != null && leftStatement.Length > 0)
            {
                String left = leftStatement.Trim();
                if (left.StartsWith("VAR "))
                {
                    String[] subLeft = left.Split(' ');
                    if (subLeft.Length == 2)
                    {
                        try
                        {
                            saveResultToVariableName = subLeft[1];
                            bool bTemp = script.AddVariable(saveResultToVariableName, "");
                            if(!bTemp)
                            {
                                 addRuntimeErrorMessages("Fail to declare variable: \"" + subLeft[1] + "\"");
                            }
                            isLeftStatementOK &= bTemp;
                        }
                        catch
                        {
                            isLeftStatementOK = false;
                            addRuntimeErrorMessages("Fail to declare variable: \"" + subLeft[1] + "\"");
                        }
                    }
                    else
                    {
                        isLeftStatementOK = false;
                        addRuntimeErrorMessages("Fail to declare variable: \"" + left + "\"");
                    }
                }
                else
                {
                    try
                    {
                        saveResultToVariableName = left;
                        object obj = script.FindVariable(saveResultToVariableName);
                        if (obj == null)
                        {
                            isLeftStatementOK = false;
                            addRuntimeErrorMessages("Variable: \"" + left + "\" doesn't exist.");
                        }
                    }
                    catch (Exception ex)
                    {
                        isLeftStatementOK = false;
                        addRuntimeErrorMessages("Fail to find the variable: \"" + left + "\" ");
                    }
                }
            }
            #endregion Left Statement
            #region Right Statement
            Command = new clsCommand(this, rightStatement.Trim(), saveResultToVariableName);
            isRightStatementOK &= Command.Compiler();
            isOK = isLeftStatementOK & isRightStatementOK;
            #endregion Right Statement
            return isOK;
        }

        public clsRunningResult Run()
        {
            clsRunningResult runningResult = new clsRunningResult();
            try
            {
                String returnVariableKey = clsVariables.KEY_CommonReturnValue;
                if (leftStatement != null && leftStatement.Length > 0)
                {
                    if (leftStatement.StartsWith("VAR "))
                    {
                        returnVariableKey = leftStatement.Substring(4).Trim();
                    }
                    else
                    {
                        returnVariableKey = leftStatement.Trim();
                    }
                }
                runningResult.ReturnValue = Command.Run();
                Logger.WriteLog(Logger.LogLevels.Verbose,"Line["+lineIndex+"]",originalString + ", RunningResult = "+runningResult.ReturnValue,true);
                script.SetVariable(returnVariableKey, runningResult.ReturnValue); //Set running result to the variable here           
            }
            catch (Exception ex)
            {
                Logger.WriteLog(Logger.LogLevels.Error, Logger.LogTags.ToolInfo.ToString(),"Unhandled exception, message = " + ex.Message+"\n"+ex.StackTrace,true);
            }
            return runningResult;
        }
        
        private void addRuntimeErrorMessages(String msg)
        {
            script.RuntimeErrorMessages.Add(new clsRuntimeErrorMessage(LineNumber, msg));
        }

        private void spilteString()
        {
            String strTemp = originalString; //Storage the processing string
            int parsedIndex = 0;
            #region Trim the remark
            if (originalString.Contains("//"))
            {
                int indexOfRemark = originalString.IndexOf("//");
                remark = originalString.Substring(indexOfRemark + 2);
                strTemp = strTemp.Substring(0, indexOfRemark);
            }
            #endregion Trim the remark
            #region Left statemate and right statemate
            parsedIndex = 0;
            leftStatement = "";
            rightStatement = "";
            if (strTemp.Contains("="))
            {
                while (strTemp.Substring(parsedIndex).Contains("="))
                {
                    parsedIndex = strTemp.IndexOf('=', parsedIndex);
                    if (parsedIndex > 0 && parsedIndex < strTemp.Length - 1)
                    {
                        char previousChar = strTemp[parsedIndex - 1];
                        char nextChar = strTemp[parsedIndex + 1];
                        if ((previousChar != ESCAPE_CHARACTER) &&
                           (previousChar != '!') &&
                           (previousChar != '>') &&
                           (previousChar != '<') &&
                           (previousChar != '=') &&
                           nextChar != '=')
                        {
                            leftStatement = strTemp.Substring(0, parsedIndex);
                            rightStatement = strTemp.Substring(parsedIndex + 1, strTemp.Length - parsedIndex - 1);
                            break;
                        }
                        else
                        {
                            parsedIndex++;
                        }
                    }
                }
            }
            else if (strTemp.Trim().StartsWith("VAR"))
            {
                leftStatement = strTemp;
                rightStatement = "";
            }
            else
            {
                leftStatement = "";
                rightStatement = strTemp;
            }
            #endregion Left statemate and right statemate
        }    
    }    
}
