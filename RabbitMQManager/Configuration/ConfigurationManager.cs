using System;
using System.Configuration;

namespace RabbitMQManager
{
    public class ConfigurationManager<T> where T : ConfigurationSection
    {
        public static T GetConfiguration(string virtualPath, string section)
        {
            var configFile = AppDomain.CurrentDomain.BaseDirectory + virtualPath;
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = configFile };

            var configuration =
                ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
     
            T configurationSection = (T)configuration.GetSection(section);
            return configurationSection;
        }
    }
}
