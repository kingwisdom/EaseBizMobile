using Geeter.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Geeter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgentDetailsPage : ContentPage
    {
        public AgentDetailsPage()
        {
            InitializeComponent();
        }
        

        public AgentDetailsPage(AgentModel model)
        {
            InitializeComponent();
            Init(model);
        }

        private void Init(AgentModel model)
        {
            name.Text = model.fullName;
            phone.Text = model.phone;
            CompanyAddress.Text = model.address;
            CompanyName.Text = model.companyName;
            CoverageArea.Text = model.city;
            state.Text = model.state;
            email.Text = model.email;
            profile.Source = model.Photo;
            dateCreated.Text = model.created_at.ToString("D");
            bio.Text = model.bio;
        }

        private async void back_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void call_Tapped(object sender, EventArgs e)
        {
            try
            {
                PhoneDialer.Open(phone.Text);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async void sms_Tapped(object sender, EventArgs e)
        {
            try
            {
                var message = new SmsMessage("Hello, ",  phone.Text);
                await Sms.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Sms is not supported on this device.
            }
            catch (Exception ex)
            {
                await DisplayAlert("", ex.Message, "Cancel");
            }
        }
    }
}