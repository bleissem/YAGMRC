using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YAGMRC.Mobile.ViewModels;

namespace YAGMRC.Mobile.Pages
{
    internal class FirstPage : ContentPage
    {
        #region constructor

        public FirstPage()
        {
            m_MainViewModel = DependencyService.Get<MainViewModel>();

            this.Title = "YAGMRC.Mobile";

            

            EntryCell ec = new EntryCell();
            ec.Label = "ID:";
            //ec.Placeholder = "Type Text Here";
            ec.BindingContext = m_MainViewModel;
            ec.SetBinding(EntryCell.TextProperty, new Binding("AuthKey", BindingMode.TwoWay));

            TableView tableView = new TableView
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

            this.Content = new StackLayout
                {
                    Children =
                   {
                    tableView,
                    loadButton
                   }
                };
        }

        void loadButton_Clicked(object sender, System.EventArgs e)
        {
            var cmd = m_MainViewModel.AuthenticateCommand;
            cmd.Execute();

            if (cmd.Result.HasResult)
            {
                //TODO: continue with loading game pages 
                int i = 0;
            }
        }

        #endregion constructor



        MainViewModel m_MainViewModel;
    }
}