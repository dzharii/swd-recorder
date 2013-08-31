using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwdPageRecorder.UI.FeaturesAndWorkarounds;

namespace SwdPageRecorder.UI
{
    public class UserNotifications
    {
        public static void NotifyUserAboutWorkaround(WorkaroundDetails details)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Title");
            sb.AppendLine("---------------");
            sb.AppendLine(details.Title);
            sb.AppendLine();

            sb.AppendLine("Details");
            sb.AppendLine("---------------");
            sb.AppendLine(details.Details);
            sb.AppendLine();


            sb.AppendLine("Info");
            sb.AppendLine("---------------");
            sb.AppendLine(details.OtherInfo);
            sb.AppendLine();

            sb.AppendLine("Workaround");
            sb.AppendLine("---------------");
            sb.AppendLine(details.Workaround);
            sb.AppendLine();

            MessageBox.Show(sb.ToString(), "Hey, you have just found a known issue!");
        }
    }
}
