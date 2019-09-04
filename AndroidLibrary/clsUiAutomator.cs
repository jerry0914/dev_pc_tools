using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev.jerry_h.pc_tools.AndroidLibrary
{
    public class clsUiAutomator : clsDeviceComponent
    {
        private clsDevice device;
        public clsUiAutomator(clsDevice device)
        {
            this.device = device;
        }
    }
}
