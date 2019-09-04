using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev.jerry_h.pc_tools.CommonLibrary
{
    internal class clsSpecialSymbolsPair
    {
        internal readonly int LeftIndex = -1;
        internal readonly int RightIndex = -1;
        internal readonly String Text = "";
        public clsSpecialSymbolsPair(int leftIndex, int rightIndex,String text)
        {
            LeftIndex = leftIndex;
            RightIndex = rightIndex;
            Text = text;
        }
    }
}
