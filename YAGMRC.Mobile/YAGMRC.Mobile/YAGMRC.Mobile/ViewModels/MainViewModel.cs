using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAGMRC.Mobile.Common;

namespace YAGMRC.Mobile.ViewModels
{
    public class MainViewModel
    {

        #region constructor

        public MainViewModel()
        {
            this.AuthKey = null;
        }

        #endregion

        #region nested classes

        public class Authenticate: ICommand, IResult<GetGamesPlayersCommandResult>
        {
            #region constructor

            public Authenticate(string authKey)
            {
                this.m_AuthKey = authKey;
                this.Result = new GetGamesPlayersCommandResult();
            }

            #endregion

            private string m_AuthKey;

            public GetGamesPlayersCommandResult Result
            {
                get;
                private set;
            }

            public async void Execute()
            {
                GiantMultiplayerRobotWebCommunication gmrwc = new GiantMultiplayerRobotWebCommunication();
                AuthenticateCommandResult authResult = await gmrwc.Authenticate(new AuthenticateCommandParam(m_AuthKey));

                this.Result = gmrwc.GetGamesAndPlayers(authResult.AuthID);
            }

            public bool CanExecute()
            {
                return !string.IsNullOrWhiteSpace(m_AuthKey);
            }
        }

        #endregion

        public string AuthKey
        {
            get;
            set;
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
