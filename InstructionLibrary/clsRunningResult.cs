using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev.jerry_h.pc_tools.InstructionLibrary
{
    public class clsRunningResult
    {
        public RunningStates RunningState = RunningStates.NONE;
        public enum RunningStates
        {
            NONE=0,
            OK=1,
            ERROR=2
        }

        private String message;
        public String Message
        {
            get
            {
                return message;
            }
        }

        public object ReturnValue = null;

        public clsRunningResult()
        {

        }

        public clsRunningResult(RunningStates state, object returnValue)
            : this(state, returnValue, "")
        {

        }

        public clsRunningResult(RunningStates state, object returnValue, String message)
        {
            ReturnValue = returnValue;
            RunningState = state;
            this.message = message;
        }
    }
}
