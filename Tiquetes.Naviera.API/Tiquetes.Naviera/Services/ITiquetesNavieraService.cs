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
        Task CreateTiquetes(Tiquete model);
        Task DeleteTiquetes(Guid id);
        Task<List<Tiquete>> GetAllTiquetes();
        Task<Tiquete> GetTiquete(Guid id);
        Task UpdateTiquetes(Tiquete model);
    }
}
