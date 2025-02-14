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
            catch (Exception) 
            {
                return null;
            }
        }

        public async Task<Serie> GetSerieAsync(string nomController, int serieId)
        {
            try
            {
                string url = string.Concat(nomController, "/", serieId);
                return await client.GetFromJsonAsync<Serie>(url);
            }
            catch (Exception) 
            {
                return null;
            }
        }

        public async Task<bool> PutSerieAsync(string nomController, Serie serie)
        {
            try
            {
                string url = string.Concat(nomController, "/", serie.Serieid);
                var reponse = await client.PutAsJsonAsync(url, serie);
                return reponse.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> PostSerieAsync(string nomController, Serie serie)
        {
            try
            {
                var reponse = await client.PostAsJsonAsync(nomController, serie);
                return reponse.IsSuccessStatusCode;
            }
            catch (Exception) 
            {
                return false;
            }
        }

        public async Task<bool> DeleteSerieAsync(string nomController, int serieId)
        {
            try
            {
                var url = string.Concat(nomController + "/", serieId);
                var reponse = await client.DeleteAsync(url);
                return reponse.IsSuccessStatusCode;
            }
            catch (Exception) 
            {
                return false;
            }
        }
    }
}
