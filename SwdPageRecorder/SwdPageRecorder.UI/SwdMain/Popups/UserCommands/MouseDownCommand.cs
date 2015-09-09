using System.Windows.Forms;

namespace SwdPageRecorder.UI.SwdMain.Popups.UserCommands
{
    public class MouseDownCommand: IUserCommand
    {
        public MouseEventArgs MouseEvent {get; set;}

        public MouseDownCommand(MouseEventArgs evt)
        {
            this.MouseEvent = evt;
        }

    }
}
