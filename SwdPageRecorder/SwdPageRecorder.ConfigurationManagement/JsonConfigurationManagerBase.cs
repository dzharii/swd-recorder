using Newtonsoft.Json.Linq;
using SwdPageRecorder.ConfigurationManagement.Internals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SwdPageRecorder.ConfigurationManagement
{
    public abstract class JsonConfigurationManagerBase<T> where T : ConfigEntryBase, new()
    {
        private string _configurationFilePath;

        public JsonConfigurationManagerBase(string configurationFilePath)
        {
            _configurationFilePath = configurationFilePath;
        }

        public T Read()
        {
            var configPath = Path.Combine(GetAssemblyDirectory(), _configurationFilePath);
            string content = File.ReadAllText(configPath);

            JObject currentConfig = JObject.Parse(@"{}");
            JArray entries = JArray.Parse(content);

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

            return currentConfig.ToObject<T>();
        }

        private bool HasJPathMatches(string applyValue, JObject jObj)
        {
            return FieldExpression.HasMatches(applyValue, jObj);
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
