using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AssetManagement.Core.Utilities
{
    public class ConfigurationHelper
    {
        private static IConfigurationRoot _configurationRoot;

        public static void ReadConfiguration(string path = "Configurations/appsettings.json")
        {
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path, true)
                .AddEnvironmentVariables()
                .Build();
        }

        public static IConfigurationRoot GetConfig()
        {
            return _configurationRoot;
        }
    }
}
