using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using YAGMRC.Mobile.Pages;

namespace YAGMRC.Mobile
{
    public class App: Application
    {

        public App()
        {
            this.MainPage = new NavigationPage(new MainPage());
        }

    }
}
