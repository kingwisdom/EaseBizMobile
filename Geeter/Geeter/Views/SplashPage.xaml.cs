using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Geeter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            imgLogo.Opacity = 0;
            await Task.WhenAny<bool>
            (
                imgLogo.FadeTo(1, 5000)
            );
            await Task.WhenAny<bool>
            (
                imgLogo.RotateTo(-DeviceDisplay.MainDisplayInfo.Width, 0, Easing.BounceOut)
            );

            if (string.IsNullOrEmpty(Preferences.Get("first", string.Empty)))
            {
                App.Current.MainPage = new NavigationPage(new StartPage());
            }
            else
            {
                App.Current.MainPage = new ShellPage();
            }
        }
    }
}