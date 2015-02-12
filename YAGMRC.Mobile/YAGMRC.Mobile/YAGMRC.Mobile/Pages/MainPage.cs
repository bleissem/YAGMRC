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

            CallWeb();

            this.Children.Add(new ContentPage
            {
                Title = "Blue",
                Content = new BoxView
                {
                    Color = Color.Blue,
                    HeightRequest = 100f,
                    VerticalOptions = LayoutOptions.Center,
                },
            });

            if (m_GetGamesAndPlayersResult.HasResult)
            {
                var games = m_GetGamesAndPlayersResult.Result.Games;
                foreach(var game in games)
                {
                    this.Children.Add(new ContentPage
                    {
                        Title = game.GameId.ToString(),
                        Content = new BoxView
                        {
                            Color = Color.Blue,
                            HeightRequest = 100f,
                            VerticalOptions = LayoutOptions.Center,
                        },
                    });
                }
            }

          
        }

        #endregion


        GetGamesPlayersCommandResult m_GetGamesAndPlayersResult;

        private async void CallWeb()
        {
            try
            {
                GiantMultiplayerRobotWebCommunication gmrwc = new GiantMultiplayerRobotWebCommunication();
                AuthenticateCommandResult authResult = await gmrwc.Authenticate(new AuthenticateCommandParam("LOXQLQ8RIA49"));

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
