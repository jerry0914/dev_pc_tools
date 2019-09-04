using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev.jerry_h.pc_tools.InstructionLibrary
{
    public class clsRuntimeErrorMessage
    {
       public readonly int LineNumber = -1;
       public readonly String Message = "";

       public clsRuntimeErrorMessage(int lineNumber, String errorMessage)
       {
           LineNumber = lineNumber;
           Message = errorMessage;
       }
    }
}
