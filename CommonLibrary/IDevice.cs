using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace dev.jerry_h.pc_tools.CommonLibrary
{
    public interface IDevice : IDisposable,IDeviceComponent
    {
        String Platform
        {
            get;
        }

        String ID
        {
            get;            
        }

        bool IsConnected
        {
            get;
        }
    }
}
