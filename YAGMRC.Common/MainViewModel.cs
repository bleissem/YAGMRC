using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YAGMRC.Core;

namespace YAGMRC.Common
{
    public class MainViewModel : IMultiplayerViewModel
    {
        #region constructor

        public MainViewModel()
        {
            this.LaunchSteam = new LaunchSteamCommand();
            this.GMRMainViewModel = new GMRMainViewModel();
        }

        #endregion

        public LaunchSteamCommand LaunchSteam { get; private set;}

        public GMRMainViewModel GMRMainViewModel { get; private set; }



    }
}
