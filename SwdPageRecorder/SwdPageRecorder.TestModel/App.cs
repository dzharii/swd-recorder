using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace SwdPageRecorder.TestModel
{
    public static class App
    {
        private static Application _instance = null;

        public static Application GetInstance()
        {
            return (_instance = _instance ?? LaunchApp());
        }

        private static Application LaunchApp()
        {
            string RecorderPath = Helper.GetRecorderAppPath();
            return Application.Launch(RecorderPath);
        }

        public static void Close()
        {
            _instance.Close();
            _instance.Dispose();
            _instance = null;
        }

        private class Finalizer
        {
            ~Finalizer()
            {
                if (_instance != null)
                {
                    _instance.Close();
                }
            }
        }


    }
}
