using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace dev.jerry_h.pc_tools.InstructionLibrary
{
    internal class clsOperationString
    {
        internal static String[] OperationSymbols = new String[]
        {
            "&",
            "|",
            "*",
            "/",
            "\\%",
            "+",
            "-",
            "==",
            ">=",
            "<=",
            "!=",
            ">",
            "<",
        };
        internal readonly MethodInfo Method = null;
        internal int StartIndex = 0;
        internal String Text = "";
        public clsOperationString(String text, int startindex)
        {
            Text = text;
            StartIndex = startindex;          
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
