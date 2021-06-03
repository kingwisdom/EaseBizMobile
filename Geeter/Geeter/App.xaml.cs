using Geeter.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: ExportFont("Poppins-Bold.otf", Alias = "BoldFont")]
[assembly: ExportFont("Poppins-Medium.otf", Alias = "MediumFont")]
[assembly: ExportFont("Poppins-Light.otf", Alias = "LightFont")]
[assembly: ExportFont("materialdesignicons.ttf", Alias = "MaterialIcons")]

namespace Geeter
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Application.Current.Resources["PrimaryColor"] = Preferences.Get("color", string.Empty) != string.Empty ? Preferences.Get("color", string.Empty) : "#3273a8"; //Color.FromHex("#fb2056");
            MainPage = new SplashPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
