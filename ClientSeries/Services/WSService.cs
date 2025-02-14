using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ClientSeries.Services;
using ClientSeries.Models;
using System.Net.Http.Json;

namespace ClientSeries.Services
{
    public class WSService : IService
    {
        private HttpClient client = new HttpClient();

        public WSService(string url)
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Serie>> GetSeriesAsync(string nomController)
        {
            try
            {
                return await client.GetFromJsonAsync<List<Serie>>(nomController);
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public async Task<Serie> GetSerieAsync(string nomController, Serie serie)
        {
            try
            {
                return await client.GetFromJsonAsync<Serie>(nomController, serie);
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public async Task<Serie> PutSerieAsync(string nomController, Serie serie)
        {
            try
            {
                var reponse = await client.PutAsJsonAsync(nomController, serie);
                return await reponse.Content.ReadFromJsonAsync<Serie>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Serie> PostSerieAsync(string nomController, Serie serie)
        {
            try
            {
                var reponse = await client.PostAsJsonAsync(nomController, serie);
                return await reponse.Content.ReadFromJsonAsync<Serie>();
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public async Task<Serie> DeleteSerieAsync(string nomController, Serie serie)
        {
            try
            {
                var reponse = await client.DeleteFromJsonAsync(nomController);
                
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
    }
}
