using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwdPageRecorder.UI.Env;

namespace SwdPageRecorder.UI.FeaturesAndWorkarounds
{

    public class WorkaroundDetails
    {
        public bool ShouldBeApplied { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string OtherInfo { get; set; }
        public string Workaround { get; set;  }
    }
    
    public static class Workaround
    {

        public static WorkaroundDetails Is_Firefox_Supported_for_Internal_driver_execution()
        {
            bool isFirefoxShouldBeDisabled = !EnvInfo.IsRunningOnWindows();
            return new WorkaroundDetails()
                {
                    ShouldBeApplied = isFirefoxShouldBeDisabled,
                    Title     = @"Bug: Cannot create FirefoxDriver with C# binding under Mono",
                    Details   = @"See details more at: https://code.google.com/p/selenium/issues/detail?id=3804",
                    OtherInfo = @"Unfortunately, DotNetZip – the WebDriver dependency has a bug," +  
                                @"which does not allow WebDriver to extract Firefox files correctly",
                    Workaround = @"Firefox driver is disabled for embed WebDriver execution on Mono." + 
                                 @"Feel free to start Firefox in Grid/Hub mode.",
                };
        }

    }
}
