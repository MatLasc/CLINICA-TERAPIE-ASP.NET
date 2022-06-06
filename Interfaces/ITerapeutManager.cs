using DAWPROIECTR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAWPROIECTR.Interfaces
{
    public interface ITerapeutManager
    {
        Task<List<TerapeutModel>> GetTerapeuti();
        Task<TerapeutModel> GetTerapeutById(int id);

        Task<TerapeutModel> UpdateTerapeut(TerapeutModel terapeutToUpdate);
        Task<TerapeutModel> InsertTerapeut(TerapeutModel terapeutToInsert);
        Task<TerapeutModel> DeleteTerapeut(TerapeutModel terapeutToDelete);
    }
}
