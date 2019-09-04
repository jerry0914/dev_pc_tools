using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev.jerry_h.pc_tools.InstructionLibrary
{
    public class clsScript 
    {
        internal bool RUN_FLAG = false;
        internal bool PUASE_FLAG = false;
        public clsPackage Package
        {
            get
            {
                return package;
            }
        }
        private clsPackage package = null;
        private clsVariables variables = new clsVariables();
        public List<clsRuntimeErrorMessage> RuntimeErrorMessages = new List<clsRuntimeErrorMessage>();
        public bool IsVariableExist(String key)
        {
            return variables.ContainsKey(key) || package.Variables.ContainsKey(key);
        }
        public Object FindVariable(String key)
        {
            if(variables.ContainsKey(key))
            {
                return variables[key];
            }
            else if (package.Variables.ContainsKey(key))
            {
                return package.Variables[key];
            }
            else
            {
                return null;
            }
        }
        public bool AddVariable(String key, object value)
        {
            if (key.Contains(' '))
            {
                return false;
            }
            else
            {
                if (variables.ContainsKey(key))
                {
                    variables[key] = value;
                }
                else
                {
                    variables.Add(key, value);
                }
                return true;
            }
        }
        public void SetVariable(String key, object value)
        {
            if (variables.ContainsKey(key))
            {
                variables[key] = value;
            }
            else if (package.Variables.ContainsKey(key))
            {
                package.Variables[key] = value;
            }
            else
            {
                variables.Add(key, value);
            }
        }
        private int tempVariableIndex = 1;
        public String GetNewTempVariableName
        {
            get
            {
                if (tempVariableIndex > 256)
                {
                    tempVariableIndex = 1;
                }
                String tmpName = "TempVariable_"+tempVariableIndex++;
                AddVariable(tmpName, "");
                return tmpName;
            }
        }    
        public List<IScriptUnit> Units = new List<IScriptUnit>();
        private String path = "";
        public clsScript(ref clsPackage package, String path)
        {
            this.package = package;
            this.path = path;
        }

        private void read()
        {
            
        }
        
        public bool Compile()
        {
            bool result = true;
            RuntimeErrorMessages.Clear();
            foreach (IScriptUnit unit in Units)
            {
                result &= unit.Compiler();
            }
            return result;
        }

        public void Run()
        {
            RUN_FLAG = true;
            foreach (IScriptUnit unit in Units)
            {
               unit.Run();
            }
        }

        public void Stop()
        {
            RUN_FLAG = false;
        }
    }
}
