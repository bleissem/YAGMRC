using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAGMRC.Core.Commands;

namespace YAGMRC.Core.ViewModels
{
    public class MainViewModel
    {

        #region Constructor

        public MainViewModel()
        {
            this.CreateGame = new CreateGameViewModel();
            this.LaunchSteam = new LaunchSteamCommand();
        }

        #endregion


        public CreateGameViewModel CreateGame{ get; private set; }

        public LaunchSteamCommand LaunchSteam { get; private set; }
    }
}
