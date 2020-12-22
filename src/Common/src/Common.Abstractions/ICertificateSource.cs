using Microsoft.Extensions.Configuration;
using System;

namespace PhnTnTi.Common
{
    public interface ICertificateSource : IConfigurationSource
    {
        Type OptionsConfigurer { get; }
    }
}
