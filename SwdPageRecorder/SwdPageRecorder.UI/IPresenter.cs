using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwdPageRecorder.UI
{
    public interface IPresenter<T>  where T : IView
    {
        void InitWithView(T view);
    }
}
