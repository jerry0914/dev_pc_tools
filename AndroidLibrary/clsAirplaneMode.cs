using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev.jerry_h.pc_tools.AndroidLibrary
{
    public class clsAirplaneMode : clsDeviceComponent
    {
        private clsDevice device = null;       
        public bool Enable
        {
            get
            {
                return ADB_Process.IsAirplaneModeOn(device.ID);
            }
            set
            {
                ADB_Process.SetAirplaneMode(device.ID, value);
            }
        }
        public bool GetEnable_InsLib()
        {
            return Enable;
        }
        public void SetEnable_InsLib(object enable)
        {
            Enable = Convert.ToBoolean(enable);
        }
        public clsAirplaneMode(clsDevice device)
        {
            this.device = device;
        }        
    }
}
