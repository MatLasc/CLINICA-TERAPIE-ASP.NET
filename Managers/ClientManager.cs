using DAWPROIECTR.Interfaces;
using DAWPROIECTR.Entities;
using DAWPROIECTR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAWPROIECTR.Managers
{
    public class ClientManager : IClientManager
    {
        private readonly IClientRepository _clientRepo;

        public ClientManager(IClientRepository clientRepo)
        {
            _clientRepo = clientRepo;
        }

        public async Task<ClientModel> DeleteClient(ClientModel clientToDelete)
        {
            var delete = new Client()
            {
                Nume = clientToDelete.Nume,
                Prenume = clientToDelete.Prenume,
                UserId = clientToDelete.UserId
            };
            await _clientRepo.Delete(delete);
            return clientToDelete;
        }

        public async Task<ClientModel> GetClientById(int id)
        {
            var client = await _clientRepo.GetById(id);
            var clientModel = new ClientModel()
            {
                Id = client.Id,
                Nume = client.Nume,
                Prenume = client.Prenume,
                UserId = client.UserId
            };
            return clientModel;
        }

        public async Task<List<ClientModel>> GetClienti()
        {
            var clienti = await _clientRepo.GetAll();
            var list = new List<ClientModel>();
            foreach (var client in clienti)
            {
                list.Add(new ClientModel()
                {
                    Id = client.Id,
                    Nume = client.Nume,
                    Prenume = client.Prenume,
                    UserId = client.UserId
                });
            }
            return list;

        }

        public async Task<ClientModel> InsertClient(ClientModel clientToInsert)
        {
            var insert = new Client()
            {
                Id = clientToInsert.Id,
                Nume = clientToInsert.Nume,
                Prenume = clientToInsert.Prenume,
                UserId = clientToInsert.UserId
            };
            await _clientRepo.Create(insert);
            return clientToInsert;
        }

        public async Task<ClientModel> UpdateClient(ClientModel clientToUpdate)
        {
            var update = new Client()
            {
                Id = clientToUpdate.Id,
                Nume = clientToUpdate.Nume,
                Prenume = clientToUpdate.Prenume,
                UserId = clientToUpdate.UserId
            };
            await _clientRepo.Update(update);
            return clientToUpdate;
        }
    }
}
