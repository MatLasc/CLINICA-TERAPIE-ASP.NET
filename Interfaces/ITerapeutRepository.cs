using DAWPROIECTR.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAWPROIECTR.Interfaces
{
    public interface ITerapeutRepository
    {
        Task<IEnumerable<Terapeut>> GetAll();
        Task<Terapeut> GetById(int id);
        Task Create(Terapeut terapeut);
        Task Update(Terapeut terapeut);
        Task Delete(Terapeut terapeut);
    }
}
