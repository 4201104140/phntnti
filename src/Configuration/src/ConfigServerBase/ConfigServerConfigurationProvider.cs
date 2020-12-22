using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PhnTnTi.Extensions.Configuration.ConfigServer
{
    /// <summary>
    /// A Spring Cloud Config Server based <see cref="ConfigurationProvider"/>
    /// </summary>
    public class ConfigServerConfigurationProvider : ConfigurationProvider, IConfigurationSource
    {
        /// <summary>
        /// The prefix (<see cref="IConfigurationSection"/> under which all Spring Cloud Config Server
        /// configuration settings (<see cref="ConfigServerClientSettings"/> are found.
        ///   (e.g. spring:cloud:config:env, spring:cloud:config:uri, spring:cloud:config:enabled, etc.)
        /// </summary>
        public const string PREFIX = "spring:cloud:config";

        public const string TOKEN_HEADER = "X-Config-Token";
        public const string STATE_HEADER = "X-Config-State";

        protected ConfigServerClientSettings _settings; // Current settings
        protected HttpClient _httpClient;
        protected ILogger _logger;
        protected ILoggerFactory _loggerFactory;
        protected IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigServerConfigurationProvider"/> class with default
        /// configuration settings. <see cref="ConfigServerClientSettings"/>
        /// </summary>
        /// <param name="logFactory">optional logging factory</param>
        public ConfigServerConfigurationProvider(ILoggerFactory logFactory = null)
            : this(new ConfigServerClientSettings(), logFactory)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigServerConfigurationProvider"/> class.
        /// </summary>
        /// <param name="settings">the configuration settings the provider uses when accessing the server.</param>
        /// <param name="logFactory">optional logging factory</param>
        public ConfigServerConfigurationProvider(ConfigServerClientSettings settings, ILoggerFactory logFactory = null)
        {
            _loggerFactory = logFactory;
            _logger = logFactory?.CreateLogger<ConfigServerConfigurationProvider>();
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _configuration = new ConfigurationBuilder().Build();
        }

        public ConfigServerConfigurationProvider(ConfigServerConfigurationSource source)
            : this(source.DefaultSettings, source.LogFactory)
        {
            _ = source.Configuration as IConfigurationRoot;
            
        }

        public virtual IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            var config = new ConfigurationBuilder();
            foreach (var s in builder.Sources)
            {
                if (s == this)
                {
                    break;
                }

                config.Add(s);
            }

            return this;
        }

    }
}
