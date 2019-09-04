using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev.jerry_h.pc_tools.InstructionLibrary
{
    public class clsVariables : Dictionary<String,object>
    {
        public const String KEY_CommonReturnValue = "__RETURNVALUE";
        public clsVariables()
        {
            this.Add(KEY_CommonReturnValue, "");
        }        
    }
}
