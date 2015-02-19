using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAGMRC.Mobile.Common;

namespace YAGMRC.Mobile.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region constructor

        public MainViewModel(Settings settings)
        {
            m_Settings = settings;

            
        }


        #endregion constructor

        #region nested classes

        public class Authenticate : ICommand, IResult<GetGamesPlayersCommandResult>
        {
            #region constructor

            public Authenticate(string authKey)
            {
                this.m_AuthKey = authKey;
                this.Result = new GetGamesPlayersCommandResult();
            }

            #endregion constructor

            private string m_AuthKey;

            public GetGamesPlayersCommandResult Result
            {
                get;
                private set;
            }

            public async void Execute()
            {
                if (!CanExecute())
                {
                    return;
                };

                GiantMultiplayerRobotWebCommunication gmrwc = new GiantMultiplayerRobotWebCommunication();
                AuthenticateCommandResult authResult = await gmrwc.Authenticate(new AuthenticateCommandParam(m_AuthKey));

                this.Result = gmrwc.GetGamesAndPlayers(authResult.AuthID);
            }

            public bool CanExecute()
            {
                return !string.IsNullOrWhiteSpace(m_AuthKey);
            }
        }

        #endregion nested classes

        private Settings m_Settings;

        

        public string AuthKey
        {
            get
            {
                return m_Settings.Auth;
            }
            set
            {
                m_Settings.Auth = value;
                base.RaisePropertyChanged(() => this.AuthKey);
            }
        }

        public Authenticate AuthenticateCommand
        {
            get
            {
                return new Authenticate(this.AuthKey);
            }
        }
    }
}