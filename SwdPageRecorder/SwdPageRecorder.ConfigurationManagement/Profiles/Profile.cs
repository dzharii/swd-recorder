using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdPageRecorder.ConfigurationManagement.Profiles
{
    public class Profile
    {
        public string DisplayName {
            get {
                return ProfileConfig.profile.displayName;
            }
        }

        public string ActivationBrowserName
        {
            get
            {
                return ProfileConfig.activation.browserName;
            }
        }

        public string ProfileId
        {
            get
            {
                return ProfileConfig.profile.profileId;
            }
        }

        public override string ToString()
        {
            return DisplayName;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

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
