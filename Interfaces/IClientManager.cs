using DAWPROIECTR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAWPROIECTR.Interfaces
{
    public interface IClientManager
    {
        Task<List<ClientModel>> GetClienti();
        Task<ClientModel> GetClientById(int id);

        Task<ClientModel> UpdateClient(ClientModel clientToUpdate);
        Task<ClientModel> InsertClient(ClientModel clientToInsert);
        Task<ClientModel> DeleteClient(ClientModel clientToDelete);
    }
}