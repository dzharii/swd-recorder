using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace SwdPageRecorder.UI.Env
{
    public static class EnvInfo
    {
        public static bool IsRunningOnWindows()
        {
            // Yes, I know it is silly
            return Path.DirectorySeparatorChar == '\\';
        }
    }
}
