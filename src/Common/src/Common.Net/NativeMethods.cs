using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static PhnTnTi.Common.Net.WindowsNetworkFileShare;

namespace PhnTnTi.Common.Net
{
    internal static class NativeMethods
    {
        [DllImport("mpr.dll", CharSet = CharSet.Unicode)]
        internal static extern int WNetAddConnection2(
            NetResource netResource,
            string password,
            string username,
            int flags);

        [DllImport("mpr.dll", CharSet = CharSet.Unicode)]
        internal static extern int WNetCancelConnection(
            string name,
            int flags,
            bool force);

        internal static extern int WNetUseConnection(
            IntPtr hwndOwner,
            NetResource netResource,
            string password,
            string username,
            int flags,
            string lpAccessName,
            string lpBufferSize,
            string lpResult)
    }
}
