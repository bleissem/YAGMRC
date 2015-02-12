using Xamarin.Forms;
using YAGMRC.Mobile.ViewModels;

namespace YAGMRC.Mobile.Pages
{
    internal class FirstPage : ContentPage
    {
        #region constructor
  
        public FirstPage()
        {
            this.Title = "YAGMRC.Mobile";
            this.Content = new BoxView()
                {
                    Color = Color.Teal,
                    HeightRequest = 100f,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand
                };
        }

        #endregion constructor

    }
}