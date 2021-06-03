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
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
            Preferences.Set("first", "FistTime");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("color", color);
            Preferences.Set("state", state);
            App.Current.MainPage = new NavigationPage(new HomePage());
        }

        string state { get; set; }
        string color { get; set; }

        private void statePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = statePicker.SelectedIndex;

            if (selectedIndex != -1)
            {
                state = (string)statePicker.ItemsSource[selectedIndex];
            }
        }

        private void colorPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = colorPicker.SelectedIndex;

            if (selectedIndex != -1)
            {
                var c = (string)colorPicker.ItemsSource[selectedIndex];
                switch (c)
                {
                    case ("Red"):
                        color = Color.DarkRed.ToHex();
                        break;
                    case ("Blue"):
                        color = Color.DarkSlateBlue.ToHex();
                        break;
                    case ("Pink"):
                        color = Color.DeepPink.ToHex();
                        break;
                    case ("Brown"):
                        color = Color.Brown.ToHex();
                        break;
                   case ("Black"):
                        color = Color.Black.ToHex();
                        break;
                   case ("Green"):
                        color = Color.Green.ToHex();
                        break;

                    default:
                        color = "#3273a8";
                        break;
                }
            }
        }
    }
}