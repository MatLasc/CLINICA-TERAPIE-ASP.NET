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
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly AppDbContext _context;

        public ClinicaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Clinica>> GetAll()
        {


            var clinici = await _context.Clinici.ToListAsync();
            return clinici;

        }

        public async Task<Clinica> GetById(int id)
        {
            var clinica = await _context.Clinici.FindAsync(id);
            return clinica;
        }

        public async Task Create(Clinica clinica)
        {
            await _context.Clinici.AddAsync(clinica);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Clinica clinica)
        {
            _context.Clinici.Update(clinica);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Clinica clinica)
        {
            _context.Clinici.Remove(clinica);
            await _context.SaveChangesAsync();
        }

        private async Task<IQueryable<Clinica>> GetAllQuery()
        {
            var query = _context.Clinici.AsQueryable();
            return query;
        }

    }
}