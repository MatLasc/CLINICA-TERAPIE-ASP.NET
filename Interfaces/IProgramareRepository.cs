using DAWPROIECTR.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAWPROIECTR.Interfaces
{
    public interface IProgramareRepository
    {
        Task<IEnumerable<Programare>> GetAll();
        Task<Programare> GetById(int id);
        Task<List<Programare>> GetByTerapeutId(int terapeutId);
        Task<List<Programare>> GetByClientId(int clientId);
        Task Create(Programare programare);
        Task Update(Programare programare);
        Task Delete(Programare programare);
    }
}
