using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAGMRC.Core.Commands;
using YAGMRC.Core.OS;

namespace YAGMRC.Core.ViewModels
{
    public class MainViewModel
    {

        #region Constructor

        public MainViewModel()
        {
            this.m_Resolver = new SimpleIoc();
            m_Resolver.Register<IOSSetting, OSSetting>(true);
            m_Resolver.Register<CreateGameViewModel>(true);


            this.CreateGame = m_Resolver.GetInstance<CreateGameViewModel>();

            this.LaunchSteam = new LaunchSteamCommand();
        }

        #endregion

        private SimpleIoc m_Resolver;

        public CreateGameViewModel CreateGame{ get; private set; }

        public LaunchSteamCommand LaunchSteam { get; private set; }
    }
}
