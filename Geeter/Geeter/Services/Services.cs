using Geeter.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Geeter.Services
{
    public static class Services
    {
        public static string url = "http://dailyinfong.com/easebis/api/";
        public static string allAgent = $"{url}agent";

        public static async Task<List<AgentModel>> GetAllAgents()
        {
            try
            {
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(allAgent);
                HttpContent httpContent = response.Content;

                var json = await httpContent.ReadAsStringAsync();

                var agents = JsonConvert.DeserializeObject<List<AgentModel>>(json);

                return agents;
            }
            catch (Exception x)
            {
                return null;
            }
        }
        
        public static async Task<List<AgentModel>> GetAllAgentsByState(string state)
        {
            try
            {
                HttpClient client = new HttpClient();
                var urls = $"{url}state/{state}";
                var response = await client.GetAsync(urls);
                HttpContent httpContent = response.Content;

                var json = await httpContent.ReadAsStringAsync();

                var agents = JsonConvert.DeserializeObject<List<AgentModel>>(json);

                return agents;
            }
            catch (Exception x)
            {
                return null;
            }
        }
    }
}
