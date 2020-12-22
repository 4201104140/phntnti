using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace PhnTnTi.Common.Net
{
    public static class DnsTools
    {
        /// <summary>
        /// Get the first listed <see cref="AddressFamily.InterNetwork" /> for the host name
        /// </summary>
        /// <param name="hostName">The host name or address to use</param>
        /// <returns>String representation of the IP Address or <see langword="null"/></returns>
        public static string ResolveHostAddress(string hostName)
        {
            try
            {
                return Dns.GetHostAddresses(hostName).FirstOrDefault(ip => ip.AddressFamily.Equals(AddressFamily.InterNetwork))?.ToString();
            }
            catch (Exception)
            {
                // Ignore
                return null;
            }
        }

        public static string ResolveHostName()
        {
            string result = null;
            try
            {
                result = Dns.GetHostName();
                if (!string.IsNullOrEmpty(result))
                {
                    var response = Dns.GetHostEntry(result);
                    if (response != null)
                    {
                        return response.HostName;
                    }
                }
            }
            catch (Exception)
            {
                // Ignore
            }

            return result;
        }
    }
}
