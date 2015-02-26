using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YAGMRC.Mobile.ViewModels;

namespace YAGMRC.Mobile.Pages
{
    internal class LoginPage : ContentPage
    {
        #region constructor

        public LoginPage()
        {
            m_MainViewModel = GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.GetInstance<MainViewModel>();

            this.Title = "YAGMRC.Mobile";
           
            EntryCell ec = new EntryCell();
            ec.Label = "ID:";
            ec.BindingContext = m_MainViewModel;
            ec.SetBinding(EntryCell.TextProperty, new Binding("AuthKey", BindingMode.TwoWay));

            TableView tableViewID = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot
                {
                    new TableSection()
                    {
                       ec
                    }
                }
            };


            Button loadButton = new Button();
            loadButton.Text = "Load";
            loadButton.Clicked += loadButton_Clicked;

            Label labelPoints = new Label();
            labelPoints.SetBinding(Label.TextProperty, new Binding("TotalPoints", BindingMode.OneWay));

            Label yourCurrentTurnsLabel = new Label()
            {
                Text = "your turns:"
            };

            ListView listViewCurrentGames = new ListView()
            {
                ItemsSource = m_MainViewModel.MyTurnsGameViewModels,
                ItemTemplate = new DataTemplate(() =>
                {
                    Label nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "Name");               

                
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Horizontal,
                            Children = 
                            {
                             
                                new StackLayout
                                {
                                    VerticalOptions = LayoutOptions.Center,
                                    Spacing = 0,
                                    Children = 
                                    {
                                        nameLabel,
                                    }
                                }
                            }
                        }
                    };
                })
            };

            this.Content = new StackLayout
                {
                    Padding = new Thickness(0,20,0,0),
                    Children =
                   {
                       yourCurrentTurnsLabel,
                       listViewCurrentGames,                      
                       tableViewID,                       
                       loadButton,                       
                       labelPoints,
                   }
                };
        }


        #endregion constructor


        void loadButton_Clicked(object sender, System.EventArgs e)
        {
            var cmd = m_MainViewModel.AuthenticateCommand;
            cmd.Execute(m_MainViewModel.AuthKey);
          
        }



        private MainViewModel m_MainViewModel;
    }
}