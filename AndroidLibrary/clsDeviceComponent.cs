using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using dev.jerry_h.pc_tools.CommonLibrary;

namespace dev.jerry_h.pc_tools.AndroidLibrary
{
    public class clsDeviceComponent : IDeviceComponent
    {
        public MethodInfo[] Methods
        {
            get
            {
                Type cls = this.GetType();
                List<MethodInfo> mtis = new List<MethodInfo>(cls.GetMethods());
                for (int index = mtis.Count - 1; index >= 0; index--)
                {
                    if (mtis[index].DeclaringType != cls || 
                       !mtis[index].IsPublic || 
                       !mtis[index].Name.EndsWith("_InsLib") // Filter the command name endwith _InsLib
                       )
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
                methodName = methodName.EndsWith("_InsLib") ? methodName : methodName + "_InsLib";
                foreach (object obj in parameters)
                {
                    lstType.Add(typeof(Object));
                }
                m = this.GetType().GetMethod(methodName, lstType.ToArray());
            }
            catch
            {

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
    }
}
