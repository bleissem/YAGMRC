using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace YAGMRC.Core.Commands
{
    public class LaunchSteamCommand : ICommand, IResult<bool>
    {
        #region Constructor

        public LaunchSteamCommand()
        {
            this.Result = false;
        }

        #endregion Constructor

        public void Execute()
        {
            if (!this.CanExecute())
            {
                this.Result = false;
                return;
            }

            try
            {
                Process p = new Process()
                {
                    StartInfo =
                    {
                        FileName = "steam://rungameid/8930",
                        UseShellExecute = true
                    }
                };
                this.Result = p.Start();
                //while(!p.HasExited)
                if (this.Result)
                {
                    //p.WaitForExit();
                }
                return;
            }
            catch (Exception ex)
            {
                this.Result = false;
                return;
            }
        }

        public bool Result
        {
            get;
            private set;
        }

        public bool CanExecute()
        {
            return true;
        }
    }
}