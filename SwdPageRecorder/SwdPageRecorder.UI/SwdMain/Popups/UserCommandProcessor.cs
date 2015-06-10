using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                var newClick = new MouseClickCommand(evt);
                Dbg<MouseClickCommand>("Added", evt);
                Trigger(newClick);
            }
        }

        private void Trigger(MouseClickCommand cmd)
        {
            if (OnMouseClick != null) OnMouseClick(cmd);
        }

        public void AddMouseMove(MouseEventArgs evt)
        {
            IUserCommand lastCommand = GetLastCommand();

            if (!(lastCommand is MouseMoveStartedCommand || lastCommand is MouseMoveFinishedCommand)) 
            {
                Commands.Add(new MouseMoveStartedCommand(evt));
                Dbg<MouseMoveStartedCommand>("Added", evt);
            }
            else if (lastCommand is MouseMoveStartedCommand)
            {
                Commands.Add(new MouseMoveFinishedCommand(evt));
                Dbg<MouseMoveFinishedCommand>("Added", evt);
            }
            else if (lastCommand is MouseMoveFinishedCommand)
            {
                (lastCommand as MouseMoveFinishedCommand).Update(evt);
                Dbg<MouseMoveFinishedCommand>("Updated", evt);
            }
            
        }

        private void Dbg<T>(string action, EventArgs evt)
        {
            MyLog.Debug(action + " " + typeof(T).Name + " " + JsonConvert.SerializeObject(evt));
        }

        
        private IUserCommand GetLastCommand()
        {
            if (Commands.Count > 0)
            {
                return Commands[Commands.Count - 1];
            }
            else 
            {
                return new NullCommand();
            }
        }

    }
}
