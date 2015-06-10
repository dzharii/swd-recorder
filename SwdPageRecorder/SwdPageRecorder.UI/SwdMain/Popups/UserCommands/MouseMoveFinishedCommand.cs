using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwdPageRecorder.UI.SwdMain.Popups.UserCommands
{
    public class MouseMoveFinishedCommand: MouseMoveAbstractCommand
    {

        public MouseMoveFinishedCommand(MouseEventArgs evt): base(evt)
        {

        }


        internal void Update(MouseEventArgs evt)
        {
            MouseEvent = evt;
        }
    }
}
