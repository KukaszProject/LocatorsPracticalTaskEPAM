using Microsoft.Extensions.Configuration;

namespace Core.Utilities
{
    public static class ConfigHelper
    {
        private static IConfigurationRoot _config;

        static ConfigHelper()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static string Get(string key)
        {
            var value = _config[key];
            if (value == null)
            {
                throw new KeyNotFoundException($"The key '{key}' was not found in the configuration.");
            }

            return value;
        }
    }
}
