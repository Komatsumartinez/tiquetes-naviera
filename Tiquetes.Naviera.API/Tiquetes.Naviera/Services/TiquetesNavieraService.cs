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

        public async Task CreateTiquetes(TiqueteDto model) => await _repo.CreateTiquetes(model);

        public async Task DeleteTiquetes(Guid id) => await _repo.DeleteTiquetes(id);
        
        public async Task<List<TiqueteDto>> GetAllTiquetes() => await _repo.GetAllTiquetes();
        
        public async Task<TiqueteDto> GetTiquete(Guid id) => await _repo.GetTiquete(id);

        public async Task UpdateTiquetes(TiqueteDto model) => await _repo.UpdateTiquetes(model);
    }
}
