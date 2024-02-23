using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiquetes.Naviera.Data;
using Tiquetes.Naviera.Models;

namespace Tiquetes.Naviera.Repository
{
    public class TiquetesNavieraServiceRepository : ITiquetesNavieraServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public TiquetesNavieraServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateTiquetes(Tiquete model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTiquetes(Guid id)
        {
            var tiquete = GetTiquete(id);
            _context.Remove(tiquete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tiquete>> GetAllTiquetes()
        {
            await _context.Database.OpenConnectionAsync();
            return await _context.Tiquetes.ToListAsync();
        }

        public async Task<Tiquete> GetTiquete(Guid id) => await _context.Tiquetes?.FirstOrDefaultAsync(t => t.Id == id);

        public async Task UpdateTiquetes(Tiquete model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
