using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev.jerry_h.pc_tools.AndroidLibrary
{
    public class clsWwanInfo
    {
        private Device device;
        private String androidID = "";
        private int simSlotNumber = 0;
        public enum MobileModes
        {
            None = 0,
            _2G = 1,
            _3G = 2,
            _4G = 4
        };
        public MobileModes MobileMoode = MobileModes.None;
        //private bool isMobileDataOn = false;
        public bool IsMobileDataConnected{
            get
            {
                return DataConectionState.Equals(DataConnectionStates.CONNECTED);
            }
        }
        private int signalStrength = -999;
        public int SignalStrength
        {
            get
            {
                return signalStrength;
            }
        }
        //private String operatorName = "";
        //public String OperatorName
        //{
        //    get
        //    {
        //        return operatorName;
        //    }
        //}
        
        private String apnName = "";
        public String APN_Name
        {
            get
            {
                return apnName;
            }
        }

        /// <summary>
        ///Call State
        ///0 - CALL_STATE_IDLE(No activity.)
        ///1 - CALL_STATE_RINGING
        ///2 - CALL_STATE_OFFHOOK
        /// </summary>
        public enum CallStates
        {
            IDLE = 0,
            RINGING = 1,
            OFFHOOK = 2
        };
        private CallStates callstate = CallStates.IDLE;
        public CallStates CallState
        {
            get
            {
                return callstate;
            }
        }
        private String incommingCallNumber = "";
        public String IncommingCallNumber
        {
            get
            {
                return incommingCallNumber;
            }
        }
        
        /// <summary>
        ///Radio service State
        ///0 - STATE_IN_SERVICE(Normal operation condition, the phone is registered with an operator either in home network or in roaming. )
        ///1 - STATE_OUT_OF_SERVICE (Phone is not registered with any operator, the phone can be currently searching a new operator to register to, or not searching to registration at all, or registration is denied, or radio signal is not available. )
        ///2 - STATE_EMERGENCY_ONLY (The phone is registered and locked. Only emergency numbers are allowed. )
        ///3 - STATE_POWER_OFF(Radio of telephony is explicitly powered off.)
        /// </summary>
        public enum ServiceStates
        {
            IN_SERVICE=0,
            OUT_OF_SERVICE=1,
            EMERGENCY_ONLY=2,
            POWER_OFF=3
        }
        public ServiceStates serviceState = ServiceStates.OUT_OF_SERVICE;
        public ServiceStates ServiceState{
            get{
                return serviceState;
            }
        }

        /// <summary>
        ///0 - Radio Data Call Activity: DATA_ACTIVITY_NONE(No traffic.)
        ///1 - DATA_ACTIVITY_IN(Currently receiving IP PPP traffic.)
        ///2 - DATA_ACTIVITY_OUT(Currently sending IP PPP traffic.)
        ///3 - DATA_ACTIVITY_INOUT(Currently both sending and receiving IP 
        /// </summary>
        public enum DataActivities
        {
            NONE=0,
            IN=1,
            OUT=2,
            IN_OUT=3
        }
        private DataActivities dataActivity = DataActivities.NONE;
        private DataActivities DataActivity
        {
            get
            {
                return dataActivity;
            }
        }

        /// <summary>
        ///Radio Data Connection State
        ///0 - DATA_DISCONNECTED (Disconnected. IP traffic not available. )
        ///1 - DATA_CONNECTING(Currently setting up a data connection.)
        ///2 - DATA_CONNECTED (Connected. IP traffic should be available.)
        ///3 - DATA_SUSPENDED (Suspended. The connection is up, but IP traffic is temporarily unavailable. For example, in a 2G network, data activity may be suspended when a voice call arrives.)
        /// </summary>
        public enum DataConnectionStates
        {
            UNKNOW=-1,
            DISCONNECTED =0,
            CONNECTING=1,
            CONNECTED=2,
            SUSPENDED=3
        }
        private DataConnectionStates dataConnectionState = DataConnectionStates.DISCONNECTED;
        public DataConnectionStates DataConectionState
        {
            get
            {
                return dataConnectionState;
            }
        }

        public clsWwanInfo(Device device,String androidID):this(device,androidID,0)
        {
        }
        public clsWwanInfo(Device device,String androidID, int simSlotNumber)
        {
            this.androidID = androidID;
            this.simSlotNumber = simSlotNumber;
            this.device = device;
        }
        
        public void RefreshState()
        {
            String refStr = "";
            String cmd = "-s "+androidID+" shell dumpsys telephony.registry";
            if(simSlotNumber==1) //SIM 2
            {
                cmd += "2";
            }
            ADB_Process.RunAdbCommand(cmd, ref refStr, false);
            foreach (String spilitedStr in refStr.Split('\n'))
            {
                String line = spilitedStr.Trim();
                String[] spilitedLine = line.Split(new char[]{'=',' '});
                int keywordIndex = 0;
                int valueIndex = 1;
                try
                {
                    switch (spilitedLine[keywordIndex])
                    {
                        #region CallState
                        case "mCallState":
                            valueIndex = 1;
                            if (spilitedLine.Length > valueIndex && spilitedLine[valueIndex] != null)
                            {
                                callstate = (CallStates)Enum.ToObject(typeof(CallStates), Convert.ToInt32(spilitedLine[valueIndex]));
                            }
                            else
                            {
                                callstate = CallStates.IDLE;
                            }
                            break;
                        #endregion CallState
                        #region Incoming Number
                        case "mCallIncomingNumber":
                            valueIndex = 1;
                            if (spilitedLine.Length > valueIndex && spilitedLine[valueIndex] != null)
                            {
                                incommingCallNumber = spilitedLine[valueIndex];
                            }
                            else
                            {
                                incommingCallNumber = "";
                            }
                            break;
                        #endregion Incoming Number
                        #region Service State & Mibile Mode
                        case "mServiceState":
                            if (spilitedLine.Length > 1)
                            {
                                if (spilitedLine[1].ToUpper().StartsWith("SIM"))
                                {
                                    valueIndex = 2;
                                }
                                else
                                {
                                    valueIndex = 1;
                                }
                                if (spilitedLine.Length > valueIndex && spilitedLine[valueIndex] != null)
                                {
                                    serviceState = (ServiceStates)Enum.ToObject(typeof(ServiceStates), Convert.ToInt32(spilitedLine[valueIndex]));
                                }
                                if (line.Contains("LTE")||
                                    line.Contains("WIMAX"))
                                {
                                    MobileMoode |= MobileModes._4G;
                                }
                                if (line.Contains("CDMA")||
                                    line.Contains("UMTS")||
                                    line.Contains("EvDO")||
                                    line.Contains("HSDPA")||
                                    line.Contains("HSUPA")||
                                    line.Contains("HSPA"))
                                                   
                                {
                                    MobileMoode |= MobileModes._3G;
                                }
                                if(line.Contains("GPRS")||
                                   line.Contains("EDGE")||
                                   line.Contains("GSM"))
                                {
                                    MobileMoode |= MobileModes._2G;
                                }
                            }
                            break;
                        #endregion Service State & Mibile Mode                        
                        #region Signal Strength
                        case "mSignalStrength":
                            if (spilitedLine.Length > 1)
                            {
                                int strength = -999;
                                try
                                {
                                    if (spilitedLine[1].ToUpper().Contains("SIM"))  //MTK Dual SIM Solution
                                    {
                                        valueIndex = spilitedLine.Length - 3;
                                        strength = Convert.ToInt32(spilitedLine[valueIndex]);
                                        strength = (int)strength / 4;
                                    }
                                    else
                                    {
                                        valueIndex = spilitedLine.Length - 6;
                                        strength = Convert.ToInt32(spilitedLine[valueIndex]);
                                    }
                                }
                                catch
                                {
                                    strength = -999;
                                }
                                signalStrength = strength;
                            }
                            break;
                        #endregion Signal Strength
                        #region DataActivity
                        case "mDataActivity":
                            valueIndex = 1;
                            if(spilitedLine.Length>valueIndex && spilitedLine[valueIndex] != null)
                            {
                               dataActivity = (DataActivities)Enum.ToObject(typeof(DataActivities), Convert.ToInt32(spilitedLine[valueIndex]));
                            }
                            break;
                        #endregion DataActivity
                        #region DataConnectionState
                        case "mDataConnectionState":
                            valueIndex = 1;
                            if (spilitedLine.Length > valueIndex && spilitedLine[valueIndex] != null)
                            {
                                dataConnectionState = (DataConnectionStates)Enum.ToObject(typeof(DataConnectionStates),Convert.ToInt32(spilitedLine[valueIndex]));
                            }
                            else
                            {
                                dataConnectionState = DataConnectionStates.UNKNOW;
                            }
                            break;
                        #endregion DataConnectionState                            
                        #region APN
                        case "mDataConnectionApn":
                            valueIndex = 1;
                            if(spilitedLine.Length>valueIndex && spilitedLine[valueIndex] != null){
                                apnName = spilitedLine[valueIndex];
                            }
                            else
                            {
                                apnName = "";
                            }
                            break;
                        #endregion APN
                        //#region
                        //case "":
                        //    valueIndex = 1;
                        //    if(spilitedLine.Length>valueIndex && spilitedLine[valueIndex] != null){

                        //    }
                        //    break;
                        //#endregion 
                    }
                }
                catch
                {

                }
            }
        }
    }
}
