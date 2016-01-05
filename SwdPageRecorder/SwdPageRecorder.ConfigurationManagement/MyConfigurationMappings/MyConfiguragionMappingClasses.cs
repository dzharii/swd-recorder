using SwdPageRecorder.ConfigurationManagement.ConfigurationFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwdPageRecorder.ConfigurationManagement.MyConfigurationMappings
{

    public class MyConfigurationCollection: List<MyConfigurationCollection.MyConfigEntry>
    {
        public class MyConfigEntry : ConfigEntryBase
        {
            public Application application { get; set; }
        }

        public class Application
        {
            public string defaultUrl { get; set; }
            public Browsersettingstab browserSettingsTab { get; set; }
            public Locatorstab LocatorsTab { get; set; }
        }

        public class Browsersettingstab
        {
            public bool useRemoteHubConnection { get; set; }
            public Remotehubconnectionsettings RemoteHubConnectionSettings { get; set; }
            public bool maximizeBrowserWindow { get; set; }
            public string defaultBrowserProfileId { get; set; }
            public bool automaticallyRunDefaultBrowserProfileWhenPageRecorderStart { get; set; }
        }

        public class Remotehubconnectionsettings
        {
            public string remoteHubUrl { get; set; }
            public bool runStartSeleniumServerBatWhenWebdriverIsNotAvailable { get; set; }
        }

        public class Locatorstab
        {
            public bool automaticallyStartWebElementExplorerWhenBrowserStarts { get; set; }
        }

    }

}
