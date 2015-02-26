using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YAGMRC.Mobile.ViewModels;


namespace YAGMRC.Mobile.Pages
{
    internal class GamePage : ContentPage
    {
        #region constructor

        private GamePage()
        {
        }

        public GamePage(GameViewModel gameViewModel)
        {
            m_GameViewModel = gameViewModel;
            this.BindingContext = m_GameViewModel;

            Title = m_GameViewModel.GameID.ToString();

            Label nameLabel = new Label();

            nameLabel.SetBinding(Label.TextProperty, "Name", BindingMode.OneWay);


            Label expireLabel = new Label();
            expireLabel.SetBinding(Label.TextProperty, "Expires", BindingMode.OneWay);

            Content = new StackLayout()
             {
                VerticalOptions = LayoutOptions.Center,
                Spacing = 0,                 
                Children =
                {
                    nameLabel,
                    expireLabel
                }
             };           
        }

        #endregion constructor

        private GameViewModel m_GameViewModel;
    }
}