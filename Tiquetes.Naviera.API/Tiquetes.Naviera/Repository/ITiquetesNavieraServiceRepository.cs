using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiquetes.Naviera.Models;

namespace Tiquetes.Naviera.Repository
{
    public interface ITiquetesNavieraServiceRepository
    {
        Task<TiqueteDto> GetTiquete(Guid id);
        Task<List<TiqueteDto>> GetAllTiquetes();
        Task CreateTiquetes(TiqueteDto model);
        Task UpdateTiquetes(TiqueteDto model);
        Task DeleteTiquetes(Guid id);
    }
}
