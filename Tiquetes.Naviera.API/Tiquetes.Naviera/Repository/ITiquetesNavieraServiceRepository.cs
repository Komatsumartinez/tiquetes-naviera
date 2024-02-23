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
        Task<Tiquete> GetTiquete(Guid id);
        Task<List<Tiquete>> GetAllTiquetes();
        Task CreateTiquetes(Tiquete model);
        Task UpdateTiquetes(Tiquete model);
        Task DeleteTiquetes(Guid id);
    }
}
