using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

namespace YAGMRC.Mobile.Droid
{
    [Activity(Label = "YAGMRC.Mobile", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);
            
            string dbPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "YAGMRC.Mobile.db3");

            LoadApplication(new App(dbPath, new SQLitePlatformAndroid()));

        }
    }
}

