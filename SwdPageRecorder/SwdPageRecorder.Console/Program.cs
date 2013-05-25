using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwdPageRecorder.UI;
using System.Windows.Forms;

namespace SwdPageRecorder.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SwdMainView());
        }
    }
}
