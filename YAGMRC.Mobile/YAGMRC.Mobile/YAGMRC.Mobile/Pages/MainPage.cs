using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YAGMRC.Mobile.Common;
using YAGMRC.Mobile.ViewModels;

namespace YAGMRC.Mobile.Pages
{
    public class MainPage : TabbedPage
    {
        #region Constructor

        public MainPage()
        {

            this.Title = "YAGMRC.Mobile";

            DependencyService.Register<MainViewModel>();
            


            FirstPage firstPage = new FirstPage();

            this.Children.Add(firstPage);

            MainViewModel mvm = DependencyService.Get<MainViewModel>();
           
            /*
            if (m_GetGamesAndPlayersResult.HasResult)
            {
                var games = m_GetGamesAndPlayersResult.Result.Games;
                foreach(var game in games)
                {
                    this.Children.Add(new GamePage(game));
                }
            }

            */
        }

        #endregion

    }
}
