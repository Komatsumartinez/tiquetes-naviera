using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiquetes.Naviera.Data;
using AutoMapper;
using Tiquetes.Naviera.Models;

namespace Tiquetes.Naviera.Repository
{
    public class TiquetesNavieraServiceRepository : ITiquetesNavieraServiceRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TiquetesNavieraServiceRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateTiquetes(TiqueteDto model)
        {
            await _context.Database.OpenConnectionAsync();
            await _context.AddAsync(_mapper.Map<Tiquete>(model));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTiquetes(Guid id)
        {
            var tiquete = GetTiquete(id);
            _context.Remove(tiquete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TiqueteDto>> GetAllTiquetes()
        {
            await _context.Database.OpenConnectionAsync();
            var tiquetes = await _context.Tiquetes.ToListAsync();
            return _mapper.Map<List<TiqueteDto>>(tiquetes);
        }

        public async Task<TiqueteDto> GetTiquete(Guid id)
        {
           var tiquete= await _context.Tiquetes?.FirstOrDefaultAsync(t => t.Id == id);
            return _mapper.Map<TiqueteDto>(tiquete);
        } 

        public async Task UpdateTiquetes(TiqueteDto model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
