using NLog;
using SwdPageRecorder.ConfigurationManagement.ConfigurationFramework;
using SwdPageRecorder.ConfigurationManagement.MyConfigurationMappings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdPageRecorder.ConfigurationManagement
{
    public class MyConfiguration : JsonConfigurationManagerBase<MyConfigurationCollection.MyConfigEntry>
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private static MyConfigurationCollection.MyConfigEntry _current = null;

        private MyConfiguration()
        {

        }

        protected override string[] GetPriorityOrderConfigurationFiles()
        {
            var result = new string[] {
                Path.Combine(GetAssemblyDirectory(), "_defaultConfiguration.json"),
                Path.Combine(GetAssemblyDirectory(), "myConfiguration.json"),
            };
            return result;
        }

        public static MyConfigurationCollection.MyConfigEntry GetCurrent()
        {
            if (_current == null)
            {
                try
                {
                    _current = new MyConfiguration().Read();
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                }
            }
            return _current;
        }
    }
}
