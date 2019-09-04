using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dev.jerry_h.pc_tools.AndroidLibrary;
using dev.jerry_h.pc_tools.CommonLibrary;

namespace dev.jerry_h.pc_tools.InstructionLibrary
{
    public class clsPackage
    {
        public static String KEY_Device = "DEV";
        public static String KEY_BasicOperation = "AT_Tool";
        internal Dictionary<String, IDevice> Devices = new Dictionary<String, IDevice>();
        private List<clsScript> scripts = new List<clsScript>();
        public clsVariables Variables = new clsVariables();
        private String scriptFolder = "";
        public clsBasicOperations BasicOperations;
        public readonly String Log_Folder = "";
        public clsPackage(Dictionary<String, IDevice> devices)
        {
            this.Devices = devices;
            BasicOperations = new clsBasicOperations();
            Log_Folder = System.AppDomain.CurrentDomain.BaseDirectory+"Logs\\";
            Logger.Initialize(Log_Folder + "Test.log");
            Logger.LogLevel = Logger.LogLevels.Verbose;
        }

        public void Load(String scriptFolder)
        {
            this.scriptFolder = scriptFolder;
        }
    }
}
