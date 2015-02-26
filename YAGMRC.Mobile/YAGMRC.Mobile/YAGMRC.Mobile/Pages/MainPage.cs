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
    public class MainPage : MasterDetailPage
    {
        #region Constructor

        public MainPage()
        {

            m_MainViewModel = GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.GetInstance<MainViewModel>();

            string title = "Home";
            Button header = new Button()
            {
                Text = title,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

           

            this.Title = title;
            this.Padding = new Thickness(0, 20, 0, 0);

                        
            ListView listViewAllGames = new ListView
            {
                ItemsSource = m_MainViewModel.GameViewModels
            };


            this.Master = new ContentPage
            {
                Title = title,
                Content = new StackLayout
                {
                    Children =
                    {
                        header,
                        listViewAllGames
                    }

                }
            };

            LoginPage loginPage = new LoginPage();

           
            this.Detail = loginPage;


            header.Clicked += (object sender, EventArgs e) =>
            {
                this.Detail = loginPage;
            };

            // For Android & Windows Phone, provide a way to get back to the master page.
            if (Device.OS != TargetPlatform.iOS)
            {
                TapGestureRecognizer tap = new TapGestureRecognizer();
                tap.Tapped += (sender, args) =>
                {
                    this.IsPresented = true;
                };
                loginPage.Content.BackgroundColor = Color.Transparent;
                loginPage.Content.GestureRecognizers.Add(tap);
            }
            // Define a selected handler for the ListView.
            listViewAllGames.ItemSelected += (sender, args) =>
            {
                /*
                // Set the BindingContext of the detail page.
                this.Detail.BindingContext = args.SelectedItem;
                // Show the detail page.
                this.IsPresented = false;
                 */
                GameViewModel gvm = args.SelectedItem as GameViewModel;
                if (null != gvm)
                {
                    this.Detail = new GamePage(gvm);
                }
            };
            // Initialize the ListView selection.
            //listView.SelectedItem = firstPage;
                     
        }


        #endregion


        MainViewModel m_MainViewModel;
    }
}
