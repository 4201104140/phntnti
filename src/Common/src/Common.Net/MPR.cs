using System;
using System.Collections.Generic;
using System.Text;
using static PhnTnTi.Common.Net.WindowsNetworkFileShare;

namespace PhnTnTi.Common.Net
{
    internal class MPR : IMPR
    {
        public MPR()
        {
            if (!Platform.IsWindows)
            {
                throw new PlatformNotSupportedException("Sorry, this functionality only works on Windows");
            }
        }

        public int AddConnection(NetResource netResource, string password, string username, int flags)
        {
            return NativeMethods
        }
    }
}
