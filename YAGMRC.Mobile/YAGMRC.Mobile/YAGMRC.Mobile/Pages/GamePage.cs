using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YAGMRC.Mobile.ViewModels;

namespace YAGMRC.Mobile.Pages
{
    internal class GamePage: ContentPage
    {
        #region constructor

        private GamePage()
        {

        }

        public GamePage(GameViewModel gameViewModel)
        {
            m_GameViewModel = gameViewModel;
            Title = m_GameViewModel.GameID.ToString();
            
            Content = new BoxView            
            {
            
                Color = Color.Blue,
                
                HeightRequest = 100f,
                
                VerticalOptions = LayoutOptions.Center,
                
            };
              
        }

        #endregion

        private GameViewModel m_GameViewModel;
    }
}
