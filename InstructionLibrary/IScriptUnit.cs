using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev.jerry_h.pc_tools.InstructionLibrary
{
    public interface IScriptUnit
    {
        int LineNumber{get;}
        clsScript Script { get; }
        List<IScriptUnit> Units { get; }
        bool Compiler();
        clsRunningResult Run();
    }
}
