using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwdPageRecorder.UI.SwdMain.Popups.UserCommands
{
    public abstract class MouseMoveAbstractCommand: IUserCommand
    {
        public MouseEventArgs MouseEvent {get; set;}

        public MouseMoveAbstractCommand(MouseEventArgs evt)
        {
            this.MouseEvent = evt;
        }

    }
}
