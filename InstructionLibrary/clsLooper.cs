using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev.jerry_h.pc_tools.InstructionLibrary
{
    public class clsLooper : IScriptUnit
    {
        public int LineNumber
        {
            get
            {
                return lineIndex + 1;
            }
        }
        private int lineIndex = 0;
        private clsScript script = null;
        public clsScript Script
        {
            get
            {
                return script;
            }
        }
        private List<IScriptUnit> units = new List<IScriptUnit>();
        public List<IScriptUnit> Units
        {
            get
            {
                return units;
            }
        }
        private int counter = 0;
        private int loop_times = 0;
        public clsLooper(ref clsScript script,int lineIndex)
        {
            this.script = script;
            this.lineIndex = lineIndex;
        }
        public clsRunningResult Run()
        {
            while (Script.RUN_FLAG && counter < loop_times)
            {
                foreach (IScriptUnit unit in units)
                {
                    unit.Run();
                    if (!Script.RUN_FLAG)
                    {
                        break;
                    }
                }
                counter++;
            }
            return new clsRunningResult(clsRunningResult.RunningStates.OK, "");
        }
        public bool Compiler()
        {
            bool isOK = false;
            return isOK;
        }
    }
}
