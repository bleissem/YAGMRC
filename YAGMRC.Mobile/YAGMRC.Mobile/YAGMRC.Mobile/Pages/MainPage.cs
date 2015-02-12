using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YAGMRC.Mobile.Pages
{
    public class MainPage : TabbedPage
    {
        #region Constructor

        public MainPage()
        {
            this.Title = "YAGMRC.Mobile";

            m_GetGamesAndPlayersResult = new GetGamesPlayersCommandResult();

            FirstPage firstPage = new FirstPage();

            this.Children.Add(firstPage);

            CallWeb(firstPage);

            if (m_GetGamesAndPlayersResult.HasResult)
            {
                var games = m_GetGamesAndPlayersResult.Result.Games;
                foreach(var game in games)
                {
                    this.Children.Add(new GamePage(game));
                }
            }

          
        }

        #endregion


        GetGamesPlayersCommandResult m_GetGamesAndPlayersResult;

        private async void CallWeb(FirstPage firstPage)
        {
            try
            {
                GiantMultiplayerRobotWebCommunication gmrwc = new GiantMultiplayerRobotWebCommunication();
                AuthenticateCommandResult authResult = await gmrwc.Authenticate(new AuthenticateCommandParam(""));

                m_GetGamesAndPlayersResult = gmrwc.GetGamesAndPlayers(authResult.AuthID);
            }
            catch(Exception ex)
            {
                var stacktrace = ex.StackTrace;
                int i = 0;
            }
        }

    }
}
