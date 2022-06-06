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
    public class TerapeutManager : ITerapeutManager
    {
        private readonly ITerapeutRepository _terapeutRepo;

        public TerapeutManager(ITerapeutRepository terapeutRepo)
        {
            _terapeutRepo = terapeutRepo;
        }

        public async Task<TerapeutModel> DeleteTerapeut(TerapeutModel terapeutToDelete)
        {
            var delete = new Terapeut()
            {
                Id = terapeutToDelete.Id,
                Nume = terapeutToDelete.Nume,
                Prenume = terapeutToDelete.Prenume,
                ClinicaId = terapeutToDelete.ClinicaId
            };
            await _terapeutRepo.Delete(delete);
            return terapeutToDelete;
        }

        public async Task<TerapeutModel> GetTerapeutById(int id)
        {
            var terapeut = await _terapeutRepo.GetById(id);
            var terapeutModel = new TerapeutModel()
            {
                Id = terapeut.Id,
                Nume = terapeut.Nume,
                Prenume = terapeut.Prenume,
                ClinicaId = terapeut.ClinicaId
            };
            return terapeutModel;
        }

        public async Task<List<TerapeutModel>> GetTerapeuti()
        {
            var terapeuti = await _terapeutRepo.GetAll();
            var list = new List<TerapeutModel>();
            foreach (var terapeut in terapeuti)
            {
                list.Add(new TerapeutModel()
                {
                    Id = terapeut.Id,
                    Nume = terapeut.Nume,
                    Prenume = terapeut.Prenume,
                    ClinicaId = terapeut.ClinicaId
                });
            }
            return list;
        }

        public async Task<TerapeutModel> InsertTerapeut(TerapeutModel terapeutToInsert)
        {
            var insert = new Terapeut()
            {
                Id = terapeutToInsert.Id,
                Nume = terapeutToInsert.Nume,
                Prenume = terapeutToInsert.Prenume,
                ClinicaId = terapeutToInsert.ClinicaId
            };
            await _terapeutRepo.Create(insert);
            return terapeutToInsert;
        }

        public async Task<TerapeutModel> UpdateTerapeut(TerapeutModel terapeutToUpdate)
        {
            var update = new Terapeut()
            {
                Nume = terapeutToUpdate.Nume,
                Prenume = terapeutToUpdate.Prenume,
                ClinicaId = terapeutToUpdate.ClinicaId
            };
            await _terapeutRepo.Update(update);
            return terapeutToUpdate;
        }
    }
}