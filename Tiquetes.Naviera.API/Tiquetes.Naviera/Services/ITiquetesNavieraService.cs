using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiquetes.Naviera.Models;

namespace Tiquetes.Naviera.Services
{
    public interface ITiquetesNavieraService
    {
        Task CreateTiquetes(TiqueteDto model);
        Task DeleteTiquetes(Guid id);
        Task<List<TiqueteDto>> GetAllTiquetes();
        Task<TiqueteDto> GetTiquete(Guid id);
        Task UpdateTiquetes(TiqueteDto model);
    }
}
