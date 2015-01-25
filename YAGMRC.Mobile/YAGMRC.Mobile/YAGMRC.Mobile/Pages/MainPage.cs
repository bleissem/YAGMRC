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

            CallWeb();

            this.Children.Add (new ContentPage 
            {
                Title = "Blue",
                Content = new BoxView
                {
                    Color = Color.Blue,
                    HeightRequest = 100f,
                    VerticalOptions = LayoutOptions.Center
                },
            });
        }

        #endregion

        private async void CallWeb()
        {
            try
            {
                GiantMultiplayerRobotWebCommunication gmrwc = new GiantMultiplayerRobotWebCommunication();
                AuthenticateCommandResult authResult = await gmrwc.Authenticate(new AuthenticateCommandParam("LOXQLQ8RIA49"));

                GetGamesPlayersCommandResult getGamesAndPlayersResult = gmrwc.GetGamesAndPlayers(authResult.AuthID);
            }
            catch(Exception ex)
            {
                int i = 0;
            }
        }

    }
}
