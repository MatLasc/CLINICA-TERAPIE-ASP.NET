using DAWPROIECTR.Entities;
using DAWPROIECTR.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAWPROIECTR.Repositories
{
    public class ProgramareRepository : IProgramareRepository
    {
        private readonly AppDbContext _context;

        public ProgramareRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Programare>> GetAll()
        {
            var programari = await _context.Programari.Include(x => x.Terapeut)
                                                       .Include(x => x.Client)
                                                       .OrderBy(x => x.Data)
                                                       .ToListAsync();
            return programari;

        }

        public async Task<Programare> GetById(int id)
        {
            var programare = await _context.Programari.FindAsync(id);
            return programare;
        }

        public async Task Create(Programare programare)
        {
            await _context.Programari.AddAsync(programare);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Programare programare)
        {
            _context.Programari.Update(programare);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Programare programare)
        {
            _context.Programari.Remove(programare);
            await _context.SaveChangesAsync();
        }

        private async Task<IQueryable<Programare>> GetAllQuery()
        {
            var query = _context.Programari.AsQueryable()
                                           .Include(x => x.Terapeut)
                                           .Include(x => x.Client)
                                           .OrderBy(x => x.Data);
            return query;
        }

        public async Task<List<Programare>> GetByTerapeutId(int terapeutId)
        {
            var programari = await _context.Programari.Include(x => x.Terapeut)
                                                 .Include(x => x.Client)
                                                 .Where(x => x.TerapeutId == terapeutId)
                                                 .ToListAsync();
            return programari;
        }

        public async Task<List<Programare>> GetByClientId(int clientId)
        {
            var programari = await _context.Programari.Include(x => x.Terapeut)
                                                 .Include(x => x.Client)
                                                 .Where(x => x.ClientId == clientId)
                                                 .ToListAsync();
            return programari;
        }
    }
}