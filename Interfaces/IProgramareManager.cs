using DAWPROIECTR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAWPROIECTR.Interfaces
{
    public interface IProgramareManager
    {
        Task<List<ProgramareModel>> GetProgramari();
        Task<ProgramareModel> GetProgramareById(int id);
        Task<List<ProgramareModel>> GetProgramariByTerapeutId(int terapeutId);
        Task<List<ProgramareModel>> GetProgramariByClientId(int clientId);

        Task<ProgramareModel> UpdateProgramare(ProgramareModel programareToUpdate);
        Task<ProgramareModel> InsertProgramare(ProgramareModel programareToInsert);
        Task<ProgramareModel> DeleteProgramare(ProgramareModel programareToDelete);

    }
}

