using DAWPROIECTR.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAWPROIECTR.Interfaces
{
    public interface IClinicaRepository
    {
        Task<IEnumerable<Clinica>> GetAll();
        Task<Clinica> GetById(int id);
        Task Create(Clinica clinica);
        Task Update(Clinica clinica);
        Task Delete(Clinica clinica);
    }
}

