using Tiquetes.Naviera.Models;
using Tiquetes.Naviera.Repository;

namespace Tiquetes.Naviera.Services
{
    public class TiquetesNavieraService : ITiquetesNavieraService
    {
        private ITiquetesNavieraServiceRepository _repo;

        public TiquetesNavieraService(ITiquetesNavieraServiceRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateTiquetes(Tiquete model) => await _repo.CreateTiquetes(model);

        public async Task DeleteTiquetes(Guid id) => await _repo.DeleteTiquetes(id);
        
        public async Task<List<Tiquete>> GetAllTiquetes() => await _repo.GetAllTiquetes();
        
        public async Task<Tiquete> GetTiquete(Guid id) => await _repo.GetTiquete(id);

        public async Task UpdateTiquetes(Tiquete model) => await _repo.UpdateTiquetes(model);
    }
}
