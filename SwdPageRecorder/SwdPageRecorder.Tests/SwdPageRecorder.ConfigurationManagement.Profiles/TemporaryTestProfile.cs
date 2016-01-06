using Newtonsoft.Json;
using SwdPageRecorder.ConfigurationManagement.Profiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdPageRecorder.Tests.SwdPageRecorder.ConfigurationManagement.Profiles
{
    public class TemporaryTestProfile : IDisposable
    {
        private bool profileWasCreated = false;
        public string ProfileFilePath { get; private set; }  = "";
        public ProfileConfigurationMapping ProfileMapping { get; set; }

        public TemporaryTestProfile()
        {
            ProfileMapping = new ProfileConfigurationMapping();
        }

        public void Create(string fileName)
        {
            ProfileFilePath = Path.Combine(ProfileDiscovery.GetProfilesDir(), fileName);
            string jsonContent = JsonConvert.SerializeObject(ProfileMapping, Formatting.Indented);
            File.WriteAllText(ProfileFilePath, jsonContent);
            profileWasCreated = true;
        }

        public void Dispose()
        {
            if (profileWasCreated)
            {
                File.Delete(ProfileFilePath);
            }
        }
    }
}
