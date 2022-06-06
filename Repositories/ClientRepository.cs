using DAWPROIECTR.Entities;
using DAWPROIECTR.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAWPROIECTR.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {

            var clienti = await _context.Clienti.ToListAsync();
            return clienti;

        }

        public async Task<Client> GetById(int id)
        {
            var client = await _context.Clienti.FindAsync(id);
            return client;
        }

        public async Task Create(Client client)
        {
            _context.Clienti.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Client client)
        {
            _context.Clienti.Update(client);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Client client)
        {
            _context.Clienti.Remove(client);
            await _context.SaveChangesAsync();
        }

        private async Task<IQueryable<Client>> GetAllQuery()
        {
            var query = _context.Clienti.AsQueryable();
            return query;
        }

    }
}