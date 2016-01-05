using Newtonsoft.Json.Linq;
using NLog;
using SwdPageRecorder.ConfigurationManagement.ConfigurationFramework.Internals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SwdPageRecorder.ConfigurationManagement.ConfigurationFramework
{
    public abstract class JsonConfigurationManagerBase<T> where T : ConfigEntryBase, new()
    {
        static Logger _logger = LogManager.GetCurrentClassLogger();

        private string[] _priorityOrderConfigurationFiles = null;

        protected abstract string[] GetPriorityOrderConfigurationFiles();

        public JsonConfigurationManagerBase()
        {

        }

        public JsonConfigurationManagerBase(string[] priorityOrderConfigurationFiles)
        {
            _priorityOrderConfigurationFiles = priorityOrderConfigurationFiles;
        }


        public T Read()
        {
            if (_priorityOrderConfigurationFiles == null) {
                _priorityOrderConfigurationFiles = GetPriorityOrderConfigurationFiles();
            }

            if (_priorityOrderConfigurationFiles == null)
            {
                _logger.Error($"{nameof(_priorityOrderConfigurationFiles)} is null");
                _priorityOrderConfigurationFiles = new string[] { };
            }

            JObject currentConfig = JObject.Parse(@"{}");

            foreach (var configurationFilePath in _priorityOrderConfigurationFiles)
            {
                if (File.Exists(configurationFilePath))
                {
                    string content = File.ReadAllText(configurationFilePath);
                    JArray entries = JArray.Parse(content);
                    MergeConfigurationEntries(currentConfig, entries);
                }
                else
                {
                    _logger.Error($"Expected configuration file {configurationFilePath} was not found");
                }
            }
            T result = currentConfig.ToObject<T>();
            return result;
        }

        private void MergeConfigurationEntries(JObject currentConfig, JArray entries)
        {
            foreach (JObject entry in entries)
            {
                string[] applyToArray = entry.GetValue("applyTo").Values<string>().ToArray();

                bool shouldMergeWithCurrent = applyToArray.Any(applyValue =>
                {
                    return applyValue.Contains("*") ||
                          applyValue.ToLower().Contains("all") ||
                          HasJPathMatches(applyValue, currentConfig);

                });

                if (shouldMergeWithCurrent)
                {
                    currentConfig.Merge(entry, new JsonMergeSettings()
                    {
                        MergeArrayHandling = MergeArrayHandling.Replace
                    });

                }
            }
        }

        private bool HasJPathMatches(string applyValue, JObject jObj)
        {
            return BooleanFieldExpression.HasMatches(applyValue, jObj);
        }

        public static string GetAssemblyDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}
