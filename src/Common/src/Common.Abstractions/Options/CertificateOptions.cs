using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace PhnTnTi.Common.Options
{
    /// <summary>
    /// Options for use with platform-provided certificates
    /// </summary>
    public class CertificateOptions
    {
        public string Name { get; set; }

        public X509Certificate2 Certificate { get; set; }

        public List<X509Certificate2> IssuerChain { get; set; } = new List<X509Certificate2>();
    }
}
