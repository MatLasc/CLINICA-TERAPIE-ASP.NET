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
    public class TerapeutRepository : ITerapeutRepository
    {
        private readonly AppDbContext _context;

        public TerapeutRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Terapeut>> GetAll()
        {
            var terapeuti = await _context.Terapeuti.ToListAsync();
            return terapeuti;

        }

        public async Task<Terapeut> GetById(int id)
        {
            var terapeut = await _context.Terapeuti.FindAsync(id);
            return terapeut;
        }

        public async Task Create(Terapeut terapeut)
        {
            await _context.Terapeuti.AddAsync(terapeut);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Terapeut terapeut)
        {
            _context.Terapeuti.Update(terapeut);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Terapeut terapeut)
        {
            _context.Terapeuti.Remove(terapeut);
            await _context.SaveChangesAsync();
        }

        private async Task<IQueryable<Terapeut>> GetAllQuery()
        {
            var query = _context.Terapeuti.AsQueryable();
            return query;
        }

    }
}