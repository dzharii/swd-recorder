using System.Windows.Forms;

namespace SwdPageRecorder.UI.SwdMain.Popups.UserCommands
{
    public class MouseClickCommand: IUserCommand
    {
        public MouseEventArgs MouseEvent {get; set;}

        public MouseClickCommand(MouseEventArgs evt)
        {
            this.MouseEvent = evt;
        }

    }
}
