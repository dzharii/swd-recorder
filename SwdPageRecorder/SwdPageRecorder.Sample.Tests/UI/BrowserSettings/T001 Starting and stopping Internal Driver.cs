using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using TestStack.BDDfy;
using TestStack.BDDfy.Scanners.StepScanners.Fluent;

using FluentAssertions;

using SwdPageRecorder.UI;
using System.Windows.Forms;

using System.Threading;


namespace SwdPageRecorder.Sample.Tests.UI.BrowserSettings
{
    
    [TestFixture]
    public class T001_Starting_and_stopping_Internal_Driver
    {

        SwdMainView mainForm = null;
        Thread thread;


        public void WFAction<T>(T control, Action action) where T : Control
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }



        SwdMainView MainForm
        {
            get
            {

                if (mainForm == null)
                {
                    mainForm = new SwdMainView();
                    thread = new Thread(delegate()
                        {
                            SWDRecorder_Program.Run(mainForm);
                        });

                    thread.Start();
                }
                
                return mainForm;
            }
        }



        public IEnumerable<Control> ExpectedControls()
        {
            yield return MainForm.txtBrowserUrl;
            yield return MainForm.btnBrowser_Go;
        }

        [Test]
        public void Before_Driver_was_started_the_depending_UI_elements_should_be_disabled()
        {
            
            this.When(_ => PrepareApplication(),        "When application is running")
                .And(_  => EmptyStep(),                 "But Driver was not started")
                .Then(_ => EnsureElementDisabled(ExpectedControls()), "Then Then ensure elements are disabled")
                .BDDfy();
        }

        private void EnsureElementDisabled(IEnumerable<Control> controls)
        {
            foreach (var control in controls)
            {
                control.Enabled.Should().BeFalse(@"{0} expected to be disabled, but was enabled", control.Name);
            }
        }


        private void EmptyStep()
        {
            
        }

        private void PrepareApplication()
        {
            
        }

        [TearDown]
        public void TearDown()
        {
            WFAction(MainForm, () => MainForm.Close());
            if (thread != null) thread.Abort();
        }


    }
}
