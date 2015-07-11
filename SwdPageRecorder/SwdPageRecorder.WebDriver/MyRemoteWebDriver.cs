using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SwdPageRecorder.WebDriver
{
    public class MyRemoteWebDriver : RemoteWebDriver, IStatusCheck
    {
        public MyRemoteWebDriver(ICapabilities desiredCapabilities) : base(desiredCapabilities) { }
        public MyRemoteWebDriver(ICommandExecutor commandExecutor, ICapabilities desiredCapabilities) : base(commandExecutor, desiredCapabilities){ }
        public MyRemoteWebDriver(Uri remoteAddress, ICapabilities desiredCapabilities) : base(remoteAddress, desiredCapabilities) { }
        public MyRemoteWebDriver(Uri remoteAddress, ICapabilities desiredCapabilities, TimeSpan commandTimeout): base(remoteAddress, desiredCapabilities, commandTimeout) { }


        public bool IsAlive()
        {
            try
            {
                var caps = this.Execute(DriverCommand.GetSessionCapabilities, null);
            }
            catch (Exception e) 
            {
                return false;
            }
            return true;
        }
    }
}
