using Geeter.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Geeter.Services
{
    public static class ApiServices
    {
        public static string url = "http://wakalagos.somee.com/api/";
        public static string allAgent = $"{url}Agent";
        public static string recentAgent = $"{url}Agent/recent";
        public static string postAgent = $"{url}Agent";
        public static string getAgentArea = $"{url}/Agent/area?Cat=";
        public static string mostview = $"{url}/Agent/patronage?id=";
        
        public static async Task<List<Agents>> GetAllAgents()
        {
            try
            {
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(allAgent);
                HttpContent httpContent = response.Content;

                var json = await httpContent.ReadAsStringAsync();

                var agents = JsonConvert.DeserializeObject<List<Agents>>(json);

                return agents;
            }
            catch (Exception x)
            {
                return null;
            }
        }

        public static async Task<List<Agents>> GetRecentAgents()
        {
            try
            {
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(recentAgent);
                HttpContent httpContent = response.Content;

                var json = await httpContent.ReadAsStringAsync();

                var agents = JsonConvert.DeserializeObject<List<Agents>>(json);

                return agents;
            }
            catch (Exception x)
            {
                return null;
            }
        }

        public static async Task<List<RecentAgent>> GetAgentArea(string area)
        {
            try
            {
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(getAgentArea+area);
                HttpContent httpContent = response.Content;

                var json = await httpContent.ReadAsStringAsync();

                var agents = JsonConvert.DeserializeObject<List<RecentAgent>>(json);

                return agents;
            }
            catch (Exception x)
            {
                return null;
            }
        }


        public static async Task<bool> PostAgentRequest(CreateAgent req)
        {
            try
            {
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(req);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
                var response = await client.PostAsync(postAgent, content);
                if (!response.IsSuccessStatusCode) return false;
                return true;
            }
            catch (Exception er)
            {
                return false;
            }

        }
        
        public static async Task<bool> IncreaseAgentCount(string req)
        {
            try
            {
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject("");
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
                var response = await client.PutAsync(mostview+req, content);
                if (!response.IsSuccessStatusCode) return false;
                return true;
            }
            catch (Exception er)
            {
                return false;
            }

        }
    }
}
