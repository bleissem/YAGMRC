using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            this.GameViewModels = new ObservableCollection<GameViewModel>();
        }


        #endregion constructor

        #region nested classes

        public class Authenticate : ICommand<string>, IResult<GetGamesPlayersCommandResult>
        {
            #region constructor

            private Authenticate()
            {

            }

            public Authenticate(Action<GetGamesPlayersCommandResult> onExecuted)
            {
              
                this.Result = new GetGamesPlayersCommandResult();
                m_OnExecuted = onExecuted;
            }

            #endregion constructor

            private string m_AuthKey;

            private Action<GetGamesPlayersCommandResult> m_OnExecuted;

            public GetGamesPlayersCommandResult Result
            {
                get;
                private set;
            }


            public async void Execute(string parameter)
            {
                this.m_AuthKey = parameter;

                if (!CanExecute())
                {
                    return;
                };

                GiantMultiplayerRobotWebCommunication gmrwc = new GiantMultiplayerRobotWebCommunication();
                AuthenticateCommandResult authResult = await gmrwc.Authenticate(new AuthenticateCommandParam(m_AuthKey));

                this.Result = gmrwc.GetGamesAndPlayers(authResult.AuthID);
                m_OnExecuted(this.Result);
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
                if (m_Settings.Auth == value)
                {
                    return;
                }


                m_Settings.Auth = value;                
                base.RaisePropertyChanged(() => this.AuthKey);
            }
        }

        private Authenticate m_Authenticate;

        public Authenticate AuthenticateCommand
        {
            get
            {
                if (null == m_Authenticate)
                {
                    m_Authenticate = new Authenticate(
                        (GetGamesPlayersCommandResult onExecuted)=>
                        {
                            if (!onExecuted.HasResult)
                            {
                                return;
                            }

                            var result = onExecuted.Result;
                            this.TotalPoints = result.CurrentTotalPoints;

                            List<GameViewModel> listGames = new List<GameViewModel>();

                            foreach (var game in result.Games)
                            {
                                listGames.Add(new GameViewModel(game));
                            }

                            this.GameViewModels = new ObservableCollection<GameViewModel>(listGames);
                        }
                        );
                }
                return m_Authenticate;
            }
        }

        private int m_TotalPoints;
        public int TotalPoints
        {
            get
            {
                return m_TotalPoints;
            }
            set
            {
                if (m_TotalPoints == value)
                {
                    return;
                }
                m_TotalPoints = value;
                base.RaisePropertyChanged(() => this.TotalPoints);
            }
        }

        public ObservableCollection<GameViewModel> GameViewModels
        {
            get;
            set;
        }
    }
}