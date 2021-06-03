using Geeter.Models;
using Geeter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Geeter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAgentPage : ContentPage
    {
        public CreateAgentPage()
        {
            InitializeComponent();
        }

        private async void post_Clicked(object sender, EventArgs e)
        {
            if(Name.Text == "" && Phone.Text == "")
            {
                await DisplayAlert("Error", "Please Your Name and Phone number is required", "Cancel");
                return;
            }
            var request = new CreateAgent()
            {
                name = Name.Text,
                companyAddress = CompanyAddress.Text,
                phone = Phone.Text,
                companyName = CompanyName.Text,
                coverageArea = CoverageArea.Text,
                imageUrl = null,
                lga = LGA.Text,
                state = State.Text,
                postedBy = "Office"
            };
            var reslt = await ApiServices.PostAgentRequest(request);
            if (reslt)
                await DisplayAlert("", "Your details is save succefully", "Ok");
            else
                await DisplayAlert("Error", "Error ocured", "Cancel");

            await Navigation.PopAsync();
        }

        private void back_Tapped(object sender, EventArgs e)
        {

        }
    }
}