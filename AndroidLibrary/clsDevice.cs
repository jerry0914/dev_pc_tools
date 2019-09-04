using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using dev.jerry_h.pc_tools.CommonLibrary;

namespace dev.jerry_h.pc_tools.AndroidLibrary
{
    public class clsDevice : clsDeviceComponent,IDevice
    {
        public String Platform
        {
            get
            {
                return "Android";
            }
        }
        private String id;
        public String ID
        {
            get
            {
                return id;
            }
        }       
        private bool isDeviceAgentReady = false;
        public bool IsConnected
        {
            get
            {
                return isDeviceAgentReady;
            }
        }    
        public clsActions Actions
        {
            get
            {
                Object obj = DeviceComponents["Actions"];
                if (obj != null)
                {
                    return (clsActions)obj;
                }
                else
                {
                    return null;
                }             
            }
        }
        public clsSIM_Info SIM1
        {
            get
            {
                Object obj = DeviceComponents["SIM1"];
                if (obj != null)
                {
                    return (clsSIM_Info)obj;
                }
                else
                {
                    return null;
                }
            }
        }
        public clsSIM_Info SIM2
        {
            get
            {
                Object obj = DeviceComponents["SIM2"];
                if (obj != null)
                {
                    return (clsSIM_Info)obj;
                }
                else
                {
                    return null;
                }
            }
        }
        public clsProductInfo ProductInfo
        {
            get
            {
                Object obj = DeviceComponents["ProductInfo"];
                if (obj != null)
                {
                    return (clsProductInfo)obj;
                }
                else
                {
                    return null;
                }
            }
        }
        public clsAirplaneMode AirplaneMode
        {
            get
            {
                Object obj = DeviceComponents["AirplaneMode"];
                if (obj != null)
                {
                    return (clsAirplaneMode)obj;
                }
                else
                {
                    return null;
                }
            }
        }
        public clsAuxiliary Auxiliary
        {
            get
            {
                Object obj = DeviceComponents["Auxiliary"];
                if (obj != null)
                {
                    return (clsAuxiliary)obj;
                }
                else
                {
                    return null;
                }
            }
        }
        public clsWifi Wifi
        {
            get
            {
                Object obj = DeviceComponents["Wifi"];
                if (obj != null)
                {
                    return (clsWifi)obj;
                }
                else
                {
                    return null;
                }
            }
        }
        public clsTelephony Telephony
        {
            get
            {
                Object obj = DeviceComponents["Telephony"];
                if (obj != null)
                {
                    return (clsTelephony)obj;
                }
                else
                {
                    return null;
                }
            }
        }

        public clsDevice(String androidID) : this(androidID, 2)
        {

        }

        public clsDevice(String androidID, int simSlotNumber)
        {
            if (androidID.Length > 0)
            {
                id = androidID;
                DeviceComponents.Add("ProductInfo", new clsProductInfo(this));
                DeviceComponents.Add("Actions", new clsActions(this));
                DeviceComponents.Add("AirplaneMode", new clsAirplaneMode(this));
                DeviceComponents.Add("Auxiliary", new clsAuxiliary(this));
                for (int index = 0; index < simSlotNumber; index++)
                {
                    DeviceComponents.Add("SIM" + (index+1).ToString(), new clsSIM_Info(this,index));                    
                }
                DeviceComponents.Add("Wifi", new clsWifi(this));
                DeviceComponents.Add("Telephony", new clsTelephony(this));
                this.Wifi.RefreshState();
            }
        }
        
        public override void Dispose()
        {
            base.Dispose();
        }

        #region AutoRefreshWwanInfo
        private bool refreshWwanInfo_flag = false;
        private Thread tdRefreshWwanInfo;
        private int refreshWwanInfo_Inberval = 15000;
        public void StartAutoRefreshWwanInfo()
        {
            refreshWwanInfo_flag = true;
            tdRefreshWwanInfo = new Thread(refreshWwanInfo_Runnable);
            tdRefreshWwanInfo.Start();
        }

        public void StartAutoRefreshWwanInfo(int refreshInterval_InMilliseconds)
        {
            refreshWwanInfo_Inberval = refreshInterval_InMilliseconds;
            StartAutoRefreshWwanInfo();
        }

        public void StopAutoRefreshWwanInfo()
        {
            refreshWwanInfo_flag = false;
            if (tdRefreshWwanInfo != null)
            {
                tdRefreshWwanInfo.Join(refreshWwanInfo_Inberval);
                tdRefreshWwanInfo.Abort();
                tdRefreshWwanInfo = null;
            }
        }

        private void refreshWwanInfo_Runnable()
        {
            DateTime startTime = DateTime.Now;
            int sleepTime = 0;
            while (refreshWwanInfo_flag)
            {
                startTime = DateTime.Now;
                if (SIM1 != null)
                {
                    SIM1.RefreshState();
                }
                if (SIM2 != null)
                {
                    SIM2.RefreshState();
                }
                sleepTime = refreshWwanInfo_Inberval - (int)DateTime.Now.Subtract(startTime).TotalMilliseconds;
                if(sleepTime>0)
                {
                    Thread.Sleep(sleepTime);
                }
            }
        }
        #endregion AutoRefreshWwanInfo              
    }
}
