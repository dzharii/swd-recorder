using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SwdPageRecorder.WebDriver.JsCommand
{
    public static class BrowserCommandParser
    {
        public static T ParseCommand<T>(string json) where T : BrowserCommand
        {
            T command = JsonConvert.DeserializeObject<T>(json);
            return command;
        }
    }
}
