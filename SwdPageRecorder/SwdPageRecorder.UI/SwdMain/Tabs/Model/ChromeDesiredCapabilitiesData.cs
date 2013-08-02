using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SwdPageRecorder.UI
{
    public class ChromeDesiredCapabilitiesData : DesiredCapabilitiesData
    {
        // https://code.google.com/p/selenium/wiki/DesiredCapabilities
        // https://code.google.com/p/chromedriver/wiki/CapabilitiesAndSwitches

        const string ChromeCaps = "Chrome-specific desired capabilities";
        
        [Category(ChromeCaps)]
        [Description(@"List of command-line arguments to use when starting Chrome. Arguments with an associated value should be separated by a '=' sign (e.g., ['start-maximized', 'user-data-dir=/tmp/temp_profile']). See here [http://peter.sh/experiments/chromium-command-line-switches/] for a list of Chrome arguments")]
        public string args { get; set; }


        [Category(ChromeCaps)]
        [Description(@"Path to the Chrome executable to use (on Mac OS X, this should be the actual binary, not just the app. e.g., '/Applications/Google Chrome.app/Contents/MacOS/Google Chrome')")]
        public string binary { get; set; }

        [Category(ChromeCaps)]
        [Description(@"A list of Chrome extensions to install on startup. Each item in the list should be a base-64 encoded packed Chrome extension (.crx)")]
        public string extensions { get; set; }

        [Category(ChromeCaps)]
        [Description(@"A dictionary with each entry consisting of the name of the preference and its value. These preferences are applied to the Local State file in the user data folder.")]
        public string localState { get; set; }

        [Category(ChromeCaps)]
        [Description(@"A dictionary with each entry consisting of the name of the preference and its value. These preferences are only applied to the user profile in use. See the 'Preferences' file in Chrome's user data directory for examples.")]
        public string prefs { get; set; }

        [Category(ChromeCaps)]
        [Description(@"If false, Chrome will be quit when ChromeDriver is killed, regardless of whether the session is quit. If true, Chrome will only be quit if the session is quit (or closed). Note, if true, and the session is not quit, ChromeDriver cannot clean up the temporary user data directory that the running Chrome instance is using.")]
        public bool? detach { get; set; }

        [Category(ChromeCaps)]
        [Description(@"version of ChromeDriver")]
        [DisplayName("chrome.chromedriverVersion")]
        public string chrome__chromedriverVersion { get; set; }

    }
}
