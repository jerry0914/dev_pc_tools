using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using dev.jerry_h.pc_tools.CommonLibrary;

namespace dev.jerry_h.pc_tools.InstructionLibrary
{
    public class clsBasicOperations : IDeviceComponent
    {
        public MethodInfo[] Methods
        {
            get
            {
                Type cls = this.GetType();
                List<MethodInfo> mtis = new List<MethodInfo>(cls.GetMethods());
                for (int index = mtis.Count - 1; index >= 0; index--)
                {
                    if (mtis[index].DeclaringType != cls || !mtis[index].IsPublic || !mtis[index].Name.EndsWith("_InsLib"))
                    {
                        mtis.RemoveAt(index);
                    }
                }
                return mtis.ToArray();
            }
        }

        public MethodInfo GetMethod(String methodName, params object[] parameters)
        {
            MethodInfo m = null;
            try
            {
                List<Type> lstType = new List<Type>();
                foreach (object obj in parameters)
                {
                    lstType.Add(obj.GetType());
                }
                this.GetType().GetMethods();
                m = this.GetType().GetMethod(methodName, lstType.ToArray());
            }
            catch
            {
                m = null;
            }
            return m;
        }
        private Dictionary<String, IDeviceComponent> deviceComponents = new Dictionary<string, IDeviceComponent>();
        public Dictionary<String, IDeviceComponent> DeviceComponents
        {
            get
            {
                return deviceComponents;
            }
        }
        public virtual void Dispose()
        {
            foreach (KeyValuePair<String, IDeviceComponent> kvp in deviceComponents)
            {
                kvp.Value.Dispose();
            }
        }

        public double ADD(object param1, object param2)
        {
            return Convert.ToDouble(param1.ToString()) + Convert.ToDouble(param2.ToString());
        }

        public double SUB(object param1, object param2)
        {
            return Convert.ToDouble(param1.ToString()) - Convert.ToDouble(param2.ToString());
        }

        public double MUL(object param1, object param2)
        {
            return Convert.ToDouble(param1.ToString()) * Convert.ToDouble(param2.ToString());
        }

        public double DIV(object param1, object param2)
        {
            double d1, d2;
            d1 = Convert.ToDouble(param1.ToString());
            d2 =  Convert.ToDouble(param2.ToString());
            if (d2 != 0)
            {
                return d1 / d2;
            }
            else
            {
                return double.PositiveInfinity;
            }
        }

        public int MOD(object param1, object param2)
        {
            int i1,i2;
            i1 = Convert.ToInt32(param1.ToString());
            i2 = Convert.ToInt32(param2.ToString());
            if (i2 != 0)
            {
                return i1 % i2;
            }
            else
            {
                return i1;
            }        
        }

        public bool AND(object param1, object param2)
        {
            return Convert.ToBoolean(param1.ToString()) & Convert.ToBoolean(param2.ToString());
        }

        public bool OR(object param1, object param2)
        {
            return Convert.ToBoolean(param1.ToString()) | Convert.ToBoolean(param2.ToString());
        }

        public bool NOT(object param1)
        {
            return !Convert.ToBoolean(param1.ToString());
        }

        public bool EQUALS(object param1, object param2)
        {
            return param1.ToString().Equals(param2.ToString());
            //return (Type.Equals(param1, param2) && param1.ToString().Equals(param2.ToString()));
        }

        public bool NOT_EQUALS(object param1, object param2)
        {
            return !EQUALS(param1,param2);
        }

        public bool GREATER_EQUAL_THAN(object param1, object param2)
        {
            return Convert.ToDouble(param1.ToString()) >= Convert.ToDouble(param2.ToString());
        }

        public bool GREATER_THAN(object param1, object param2)
        {
            return Convert.ToDouble(param1.ToString()) > Convert.ToDouble(param2.ToString());
        }

        public bool LESS_EQUAL_THAN(double param1, double param2)
        {
            return !GREATER_THAN(param1.ToString(), param2.ToString());
        }

        public bool LESS_THAN(double param1, double param2)
        {
            return !GREATER_EQUAL_THAN(param1, param2);
        }

        public void Wait_InsLib(object iDuartionInMilliseconds)
        {
            Thread.Sleep(Convert.ToInt32(iDuartionInMilliseconds));
        }

        public void WriteLog_CheckPoint_InsLib(object bResult, object strMessage)
        {
            Logger.WriteLog("CheckPoint", strMessage.ToString() + ", result: " + ((Convert.ToBoolean(bResult)) ? "PASS" : "FAIL"));
        }

        public void WriteLog_InsLib(object strTag, object strMessage)
        {
            Logger.WriteLog(strTag.ToString(), strMessage.ToString());
        }

        private void MathTest()
        {
            
        }
    }
}
