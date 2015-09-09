using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using SwdPageRecorder.UI.SwdMain.Popups.UserCommands;
using SwdPageRecorder.WebDriver;

namespace SwdPageRecorder.UI.SwdMain.Popups
{
    public class UserCommandProcessor
    {
        public event Action<MouseClickCommand> OnMouseClick = null;
        public List<IUserCommand> Commands { get; private set; }
        public UserCommandProcessor()
        {
            Commands = new List<IUserCommand>();
        }

        public void AddMouseDown(MouseEventArgs evt) 
        {
            IUserCommand lastCommand = GetLastCommand();
            var mouseDown = new MouseDownCommand(evt);
            Commands.Add(mouseDown);
            Dbg<MouseDownCommand>("Added", evt);
        }

        public void AddMouseUp(MouseEventArgs evt)
        {
            IUserCommand lastCommand = GetLastCommand();

            var mouseUp = new MouseUpCommand(evt);
            Commands.Add(mouseUp);
            Dbg<MouseUpCommand>("Added", evt);

            if (lastCommand is MouseDownCommand) 
            {
                if (AreCoordinatesClose(mouseUp, lastCommand as MouseDownCommand, 3))
                {
                    var newClick = new MouseClickCommand(evt);
                    Dbg<MouseClickCommand>("Added", evt);
                    Trigger(newClick);
                }
                else {
                    Dbg<MouseClickCommand>("MouseClickCommand was not triggered because MouseUp/Down coordinates were not close enough", evt);
                }
            }
        }

        private bool AreCoordinatesClose(MouseUpCommand mouseUp, MouseDownCommand mouseDown, int pixelTollerance)
        {
            if (mouseUp == null) return false;
            if (mouseDown == null) return false;

            bool isCloseX = Math.Abs(mouseUp.MouseEvent.X - mouseDown.MouseEvent.X) <= pixelTollerance;
            bool isCloseY = Math.Abs(mouseUp.MouseEvent.Y - mouseDown.MouseEvent.Y) <= pixelTollerance;
            return isCloseX && isCloseY;

        }

        private void Trigger(MouseClickCommand cmd)
        {
            if (OnMouseClick != null) OnMouseClick(cmd);
        }


        private void Dbg<T>(string action, EventArgs evt)
        {
            MyLog.Debug(action + " " + typeof(T).Name + " " + JsonConvert.SerializeObject(evt));
        }

        
        private IUserCommand GetLastCommand(Func<IUserCommand, bool> predicate = null)
        {
            IUserCommand result;
            if (predicate != null)
            {
                result = Commands.LastOrDefault(predicate);
            }
            else
            {
                result = Commands.LastOrDefault();
            }

            result = result ?? new NullCommand();

            return result;
        }
    }
}
