using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientSeries.Models;

namespace ClientSeries.Services
{
    public interface IService
    {
        Task<List<Serie>> GetSeriesAsync(string nomControleur);

        Task<Serie> GetSerieAsync(string nomController, int serieId);

        Task<bool> PutSerieAsync(string nomController, Serie serie);

        Task<bool> PostSerieAsync(string nomController, Serie serie);

        Task<bool> DeleteSerieAsync(string nomController, int serieId);
    }
}
