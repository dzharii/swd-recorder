using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SwdPageRecorder.UI
{
    public class DesiredCapabilitiesData
    {
        // https://code.google.com/p/selenium/wiki/DesiredCapabilities
        // http://www.rsdn.ru/article/dotnet/PropertyGridFAQ.xml

        const string catUsedBySelServerForBrowserSelection = "Used by the selenium server for browser selection";
        
        [Category(catUsedBySelServerForBrowserSelection)]
        [Description(@"The name of the browser being used; should be one of {android|chrome|firefox|htmlunit|internet explorer|iPhone|iPad|opera|safari}.")]
        public string browserName { get; set; }


        [Category(catUsedBySelServerForBrowserSelection)]
        [Description(@"The browser version, or the empty string if unknown.")]
        public string version { get; set; }

        [Category(catUsedBySelServerForBrowserSelection)]
        [Description(@"A key specifying which platform the browser should be running on. This value should be one of {WINDOWS|XP|VISTA|MAC|LINUX|UNIX|ANDROID}. When requesting a new session, the client may specify ANY to indicate any available platform may be used.")]
        public string platform { get; set; }



        const string catReadonlyCapabilities = "Read-only capabilities";
        
        [Category(catReadonlyCapabilities)]
        [ReadOnly(true)]
        [Description(@"Whether the session supports taking screenshots of the current page.")]
        public bool? takesScreenshot { get; set; }

        [Category(catReadonlyCapabilities)]
        [ReadOnly(true)]
        [Description(@"Whether the session can interact with modal popups, such as window.alert and window.confirm.")]
        public bool? handlesAlerts { get; set; }

        [Category(catReadonlyCapabilities)]
        [ReadOnly(true)]
        [Description(@"Whether the session supports CSS selectors when searching for elements.")]
        public bool? cssSelectorsEnabled { get; set; }



        const string catReadWriteCapabilities = "Read-write capabilities";

        [Category(catReadWriteCapabilities)]
        [Description(@"Whether the session supports executing user supplied JavaScript in the context of the current page (only on HTMLUnitDriver).")]
        public bool? javascriptEnabled {get; set;} 

        [Category(catReadWriteCapabilities)]
        [Description(@"Whether the session can interact with database storage.")]
        public bool? databaseEnabled {get; set;} 

        [Category(catReadWriteCapabilities)]
        [Description(@"Whether the session can set and query the browser's location context.")]
        public bool? locationContextEnabled {get; set;} 

        [Category(catReadWriteCapabilities)]
        [Description(@"Whether the session can interact with the application cache.")]
        public bool? applicationCacheEnabled {get; set;} 

        [Category(catReadWriteCapabilities)]
        [Description(@"Whether the session can query for the browser's connectivity and disable it if desired.")]
        public bool? browserConnectionEnabled {get; set;} 

        [Category(catReadWriteCapabilities)]
        [Description(@"Whether the session supports interactions with storage objects.")]
        public bool? webStorageEnabled {get; set;} 

        [Category(catReadWriteCapabilities)]
        [Description(@"Whether the session should accept all SSL certs by default.")]
        public bool? acceptSslCerts {get; set;} 

        [Category(catReadWriteCapabilities)]
        [Description(@"Whether the session can rotate the current page's current layout between portrait and landscape orientations (only applies to mobile platforms).")]
        public bool? rotatable {get; set;} 

        [Category(catReadWriteCapabilities)]
        [Description(@"Whether the session is capable of generating native events when simulating user input.")]
        public bool? nativeEvents {get; set;} 

        [Category(catReadWriteCapabilities)]
        [Description(@"// Not Supported in SWD Page Recorder// Details of any proxy to use. If no proxy is specified, whatever the system's current or default state is used. The format is specified under Proxy JSON Object.")]
        [ReadOnly(true)]
        public string proxy {get; set;} 

        [Category(catReadWriteCapabilities)]
        [Description(@"What the browser should do with an unhandled alert before throwing out the UnhandledAlertException. Possible values are ""accept"", ""dismiss"" and ""ignore""")]
        public string unexpectedAlertBehaviour {get; set;} 



    }
}
