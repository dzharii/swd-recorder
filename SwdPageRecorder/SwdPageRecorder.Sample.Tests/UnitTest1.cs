using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwdPageRecorder.UI;
using System.Windows.Forms;

namespace SwdPageRecorder.Sample.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SwdMainView());
        }
    }
}
