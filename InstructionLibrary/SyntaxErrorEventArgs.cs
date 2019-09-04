using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev.jerry_h.pc_tools.InstructionLibrary
{
    public class SyntaxErrorEventArgs : EventArgs
    {
        public readonly int LineNumber = -1;
        public String OriginalString = "";
        public String Message = "";
        public SyntaxErrorEventArgs(int lineNum, String originalString, String message)
        {
            LineNumber = lineNum;
            OriginalString = originalString;
            Message = message;
        }
    }
}
