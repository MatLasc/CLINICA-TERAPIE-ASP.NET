using DAWPROIECTR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAWPROIECTR.Interfaces
{
    public interface IClinicaManager
    {
        Task<List<ClinicaModel>> GetClinici();
        Task<ClinicaModel> GetClinicaById(int id);

        Task<ClinicaModel> UpdateClinica(ClinicaModel clinicaToUpdate);
        Task<ClinicaModel> InsertClinica(ClinicaModel clinicaToInsert);
        Task<ClinicaModel> DeleteClinica(ClinicaModel clinicaToDelete);
    }
}

