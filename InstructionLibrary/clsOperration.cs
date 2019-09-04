using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace dev.jerry_h.pc_tools.InstructionLibrary
{
    public class clsOperration
    {
        private Object param1, param2;
        private Object value1, value2;
        private MethodInfo operationMethod = null;
        public clsOperration(object param1, object param2, MethodInfo operationMethod)
        {
            this.param1 = param1;
            this.param2 = param2;
            this.operationMethod = operationMethod;
        }

        public Object Run()
        {
            if (param1.GetType().Equals(typeof(clsOperration)))
            {
                value1 = ((clsOperration)param1).Run();
            }
            else
            {
                value1 = param1;
            }
            if (param2.GetType().Equals(typeof(clsOperration)))
            {
                value2 = ((clsOperration)param2).Run();
            }
            else
            {
                value2 = param2;
            }
            return operationMethod.Invoke(this, new Object[] { param1, param2 });
        }
    }
}
