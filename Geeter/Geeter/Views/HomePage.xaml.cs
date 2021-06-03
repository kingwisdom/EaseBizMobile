using Geeter.Models;
using Geeter.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Geeter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            Application.Current.Resources["PrimaryColor"] = Preferences.Get("color", string.Empty) != string.Empty ? Preferences.Get("color", string.Empty) : "#3273a8";
            Agents = new ObservableCollection<AgentModel>();

            Populate();
        }
        ObservableCollection<AgentModel> Agents;
        private async void Populate()
        {
            loading.IsVisible = true;
            var state = Preferences.Get("state", string.Empty);
            List<AgentModel> response = new List<AgentModel>();

            if (!string.IsNullOrEmpty(state))
            {
                response = await Services.Services.GetAllAgentsByState(state);
            }
            else
            {
                 response = await Services.Services.GetAllAgents();
            }
            if (response != null)
            {
                foreach (var item in response)
                {
                    Agents.Add(item);
                }
            }

            loading.IsVisible = false;
            agentList.ItemsSource = Agents;
        }

        private async void add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateAgentPage());
        }

        private void agentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var item = (AgentModel)e.CurrentSelection[0];
            //Navigation.PushAsync(new AgentDetailsPage(item));

            var current = e.CurrentSelection.FirstOrDefault() as AgentModel;
            if (current == null) return;
            Navigation.PushModalAsync(new AgentDetailsPage(current));
            ((CollectionView)sender).SelectedItem = null;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

    
    }
}