using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdPageRecorder.ConfigurationManagement.Profiles
{
    public class Profile
    {
        public ProfileConfigurationMapping ProfileConfig { get; set; }
        public bool HasErrors { get; set; }
        public Exception Exception { get; set; }
        public string FileName { get; set; }

        public Profile()
        {
            ProfileConfig = new ProfileConfigurationMapping();
        }
    }
}
