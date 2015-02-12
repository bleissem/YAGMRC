using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YAGMRC.Mobile.Pages
{
    internal class GamePage: ContentPage
    {
        #region constructor

        private GamePage()
        {

        }

        public GamePage(Model.GetGamesAndPlayers.Game game)
        {

            Title = game.GameId.ToString();
            
            Content = new BoxView            
            {
            
                Color = Color.Blue,
                
                HeightRequest = 100f,
                
                VerticalOptions = LayoutOptions.Center,
                
            };
              
        }

        #endregion
    }
}
