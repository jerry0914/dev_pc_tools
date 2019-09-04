using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev.jerry_h.pc_tools.InstructionLibrary
{
    internal class clsOperandString
    {
       internal readonly int StartIndex = 0;
       internal readonly String Text = "";
       public clsOperandString(String text,int startIndex)
       {
           Text = text;
           StartIndex = startIndex;
       }

       public override string ToString()
       {
           return Text;
       }
    }
}
