using GalaSoft.MvvmLight.Ioc;
using SQLite.Net.Interop;
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
        #region ctor

        private App()
        {

        }

        public App(string dbPath, ISQLitePlatform platform)
        {
            Settings settings = new Settings(dbPath, platform);
            SimpleIoc.Default.Register<Settings>(() => settings, true);

            SimpleIoc.Default.Register<YAGMRC.Mobile.ViewModels.MainViewModel>(() => new YAGMRC.Mobile.ViewModels.MainViewModel(settings), true);

            this.MainPage = new NavigationPage(new MainPage());
        }

        #endregion

    }
}
