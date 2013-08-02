using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SwdPageRecorder.UI
{
    public class IEDesiredCapabilitiesData : DesiredCapabilitiesData
    {
        // https://code.google.com/p/selenium/wiki/DesiredCapabilities

        const string IECaps = "IE-specific desired capabilities";
        
        [Category(IECaps)]
        [Description(@"Whether to skip the protected mode check. If set, tests may become flaky, unresponsive, or browsers may hang. If not set, and protected mode settings are not the same for all zones, an exception will be thrown on driver construction. Only ""best effort"" support is provided when using this capability.")]
        public bool? ignoreProtectedModeSettings { get; set; }


        [Category(IECaps)]
        [Description(@"Indicates whether to skip the check that the browser's zoom level is set to 100%. Value is set to false by default.")]
        public bool? ignoreZoomSetting { get; set; }

        [Category(IECaps)]
        [Description(@"Allows the user to specify the initial URL loaded when IE starts. Intended to be used with ignoreProtectedModeSettings to allow the user to initialize IE in the proper Protected Mode zone. Using this capability may cause browser instability or flaky and unresponsive code. Only ""best effort"" support is provided when using this capability.")]
        public string initialBrowserUrl { get; set; }

        [Category(IECaps)]
        [Description(@"Allows the user to specify whether elements are scrolled into the viewport for interaction to align with the top (0) or bottom (1) of the viewport. The default value is to align with the top of the viewport.")]
        public int? elementScrollBehavior { get; set; }

        [Category(IECaps)]
        [Description(@"Determines whether persistent hovering is enabled (true by default). Persistent hovering is achieved by continuously firing mouse over events at the last location the mouse cursor has been moved to.")]
        public bool? enablePersistentHover { get; set; }

        [Category(IECaps)]
        [Description(@"Determines whether the driver should attempt to remove obsolete elements from the element cache on page navigation (true by default). This is to help manage the IE driver's memory footprint, removing references to invalid elements.")]
        public bool? enableElementCacheCleanup { get; set; }

        [Category(IECaps)]
        [Description(@"Determines whether to require that the IE window have focus before performing any user interaction operations (mouse or keyboard events). This capability is false by default, but delivers much more accurate native events interactions.")]
        public bool? requireWindowFocus { get; set; }

        [Category(IECaps)]
        [Description(@"The timeout, in milliseconds, that the driver will attempt to locate and attach to a newly opened instance of Internet Explorer. The default is zero, which indicates waiting indefinitely.")]
        public int? browserAttachTimeout { get; set; }

        [Category(IECaps)]
        [Description(@"Forces launching Internet Explorer using the CreateProcess API. If this option is not specified, IE is launched using the IELaunchURL, if it is available. For IE 8 and above, this option requires the TabProcGrowth registry value to be set to 0.")]
        [DisplayName("ie.forceCreateProcessApi")]
        public bool? ie__forceCreateProcessApi { get; set; }

        [Category(IECaps)]
        [Description(@"Specifies command-line switches with which to launch Internet Explorer. This is only valid when used with the forceCreateProcess.")]
        [DisplayName("ie.browserCommandLineSwitches")]
        public string ie__browserCommandLineSwitches { get; set; }

        [Category(IECaps)]
        [Description(@"When a proxy is specified using the proxy capability, this capability sets the proxy settings on a per-process basis when set to true. The default is false, which means the proxy capability will set the system proxy, which IE will use.")]
        [DisplayName("ie.usePerProcessProxy")]
        public bool? ie__usePerProcessProxy { get; set; }

        [Category(IECaps)]
        [Description(@"When set to true, this capability clears the cache, cookies, history, and saved form data. When using this capability, be aware that this clears the cache for all running instances of Internet Explorer, including those started manually.")]
        [DisplayName("ie.ensureCleanSession")]
        public bool? ie__ensureCleanSession { get; set; }

        [Category(IECaps)]
        [Description(@"The path to file where server should write log messages to. By default it writes to stdout.")]
        public string logFile { get; set; }

        [Category(IECaps)]
        [Description(@"The log level used by the server. Valid values are TRACE, DEBUG, INFO, WARN, ERROR, and FATAL. Defaults to FATAL if not specified.")]
        public string logLevel { get; set; }

        [Category(IECaps)]
        [Description(@"The address of the host adapter on which the server will listen for commands.")]
        public string host { get; set; }

        [Category(IECaps)]
        [Description(@"The path to the directory used to extract supporting files used by the server. Defaults to the TEMP directory if not specified.")]
        public string extractPath { get; set; }

        [Category(IECaps)]
        [Description(@"Suppresses diagnostic output when the server is started.")]
        public bool? silent { get; set; }
    }
}
