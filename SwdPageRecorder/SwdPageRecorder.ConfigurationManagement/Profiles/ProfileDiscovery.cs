using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SwdPageRecorder.ConfigurationManagement.Profiles
{
    public class ProfileDiscovery
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static readonly string ProfileFileMaskSearchPattern = "*Profile.json";
        public static string GetProfilesDir()
        {
            return Path.Combine(GetAssemblyDirectory(), "profiles");
        }

        private static string GetAssemblyDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        public Profile[] Discover()
        {
            var resultProfilesList = new List<Profile>();
            IEnumerable<string> files = Directory.EnumerateFiles(GetProfilesDir(), ProfileFileMaskSearchPattern);
            foreach (var file in files)
            {
                var profile = new Profile();
                profile.FileName = Path.GetFileName(file);
                try
                {
                    string fileContent = File.ReadAllText(file);
                    JObject parser = JObject.Parse(fileContent);
                    var parsedProfile = parser.ToObject<ProfileConfigurationMapping>();
                    profile.ProfileConfig = parsedProfile;
                }
                catch (Exception ex)
                {
                    profile.HasErrors = true;
                    profile.Exception = ex;
                    _logger.Error(ex);
                }
                resultProfilesList.Add(profile);
            }

            resultProfilesList = resultProfilesList.OrderBy(item => item.ProfileConfig.profile.displayPriority)
                                                   .ThenBy(item => item.DisplayName)
                                                   .ToList();

            return resultProfilesList.ToArray();
        }
    }
}
