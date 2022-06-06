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
    public class ProgramareManager : IProgramareManager
    {
        private readonly IProgramareRepository _programareRepo;

        public ProgramareManager(IProgramareRepository programareRepo)
        {
            _programareRepo = programareRepo;
        }

        public async Task<ProgramareModel> DeleteProgramare(ProgramareModel programareToDelete)
        {
            var delete = new Programare()
            {
                Id = programareToDelete.Id,
                Plata = programareToDelete.Plata,
                Data = programareToDelete.Data,
                ClientId = programareToDelete.ClientId,
                TerapeutId = programareToDelete.TerapeutId
            };
            await _programareRepo.Delete(delete);
            return programareToDelete;
        }

        public async Task<ProgramareModel> GetProgramareById(int id)
        {
            var programare = await _programareRepo.GetById(id);
            var programareModel = new ProgramareModel()
            {
                Id = programare.Id,
                Plata = programare.Plata,
                Data = programare.Data,
                ClientId = programare.ClientId,
                TerapeutId = programare.TerapeutId
            };
            return programareModel;
        }

        public async Task<List<ProgramareModel>> GetProgramari()
        {
            var programari = await _programareRepo.GetAll();
            var list = new List<ProgramareModel>();
            foreach (var programare in programari)
            {
                list.Add(new ProgramareModel()
                {
                    Id = programare.Id,
                    Plata = programare.Plata,
                    Data = programare.Data,
                    ClientId = programare.ClientId,
                    TerapeutId = programare.TerapeutId
                });
            }
            return list;
        }

        public async Task<List<ProgramareModel>> GetProgramariByClientId(int clientId)
        {
            var programari = await _programareRepo.GetByClientId(clientId);
            var list = new List<ProgramareModel>();
            foreach (var programare in programari)
            {
                list.Add(new ProgramareModel()
                {
                    Id = programare.Id,
                    Plata = programare.Plata,
                    Data = programare.Data,
                    ClientId = programare.ClientId,
                    TerapeutId = programare.TerapeutId
                });
            }
            return list;
        }

        public async Task<List<ProgramareModel>> GetProgramariByTerapeutId(int terapeutId)
        {
            var programari = await _programareRepo.GetByTerapeutId(terapeutId);
            var list = new List<ProgramareModel>();
            foreach (var programare in programari)
            {
                list.Add(new ProgramareModel()
                {
                    Id = programare.Id,
                    Plata = programare.Plata,
                    Data = programare.Data,
                    ClientId = programare.ClientId,
                    TerapeutId = programare.TerapeutId
                });
            }
            return list;
        }

        public async Task<ProgramareModel> InsertProgramare(ProgramareModel programareToInsert)
        {
            var insert = new Programare()
            {
                Id = programareToInsert.Id,
                Plata = programareToInsert.Plata,
                Data = programareToInsert.Data,
                ClientId = programareToInsert.ClientId,
                TerapeutId = programareToInsert.TerapeutId
            };
            await _programareRepo.Create(insert);
            return programareToInsert;
        }

        public async Task<ProgramareModel> UpdateProgramare(ProgramareModel programareToUpdate)
        {
            var update = new Programare()
            {
                Plata = programareToUpdate.Plata,
                Data = programareToUpdate.Data,
                ClientId = programareToUpdate.ClientId,
                TerapeutId = programareToUpdate.TerapeutId
            };
            await _programareRepo.Update(update);
            return programareToUpdate;
        }
    }
}
