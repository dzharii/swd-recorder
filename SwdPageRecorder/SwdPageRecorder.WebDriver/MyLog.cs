using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace SwdPageRecorder.WebDriver
{
    public static class MyLog
    {
        static Logger logger = LogManager.GetLogger("SWD");

        public static void Exception(Exception e)
        {
            logger.ErrorException(e.Message, e);
        }

        public static void Write(string message)
        {
            logger.Info(message);
        }
    }
}
