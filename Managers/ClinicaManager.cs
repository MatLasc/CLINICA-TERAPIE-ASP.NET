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
    public class ClinicaManager : IClinicaManager
    {
        private readonly IClinicaRepository _clinicaRepo;

        public ClinicaManager(IClinicaRepository clinicaRepo)
        {
            _clinicaRepo = clinicaRepo;
        }

        public async Task<ClinicaModel> DeleteClinica(ClinicaModel clinicaToDelete)
        {
            var delete = new Clinica()
            {
                Id = clinicaToDelete.Id,
                Oras = clinicaToDelete.Oras,
                Adresa = clinicaToDelete.Adresa
            };
            await _clinicaRepo.Delete(delete);
            return clinicaToDelete;
        }

        public async Task<ClinicaModel> GetClinicaById(int id)
        {
            var clinica = await _clinicaRepo.GetById(id);
            var clinicaModel = new ClinicaModel()
            {
                Id = clinica.Id,
                Oras = clinica.Oras,
                Adresa = clinica.Adresa
            };
            return clinicaModel;
        }

        public async Task<List<ClinicaModel>> GetClinici()
        {
            var clinici = await _clinicaRepo.GetAll();
            var list = new List<ClinicaModel>();
            foreach (var clinica in clinici)
            {
                list.Add(new ClinicaModel()
                {
                    Id = clinica.Id,
                    Oras = clinica.Oras,
                    Adresa = clinica.Adresa
                });
            }
            return list;

        }

        public async Task<ClinicaModel> InsertClinica(ClinicaModel clinicaToInsert)
        {
            var insert = new Clinica()
            {
                Id = clinicaToInsert.Id,
                Oras = clinicaToInsert.Oras,
                Adresa = clinicaToInsert.Adresa
            };
            await _clinicaRepo.Create(insert);
            return clinicaToInsert;
        }

        public async Task<ClinicaModel> UpdateClinica(ClinicaModel clinicaToUpdate)
        {
            var update = new Clinica()
            {
                Oras = clinicaToUpdate.Oras,
                Adresa = clinicaToUpdate.Adresa
            };
            await _clinicaRepo.Update(update);
            return clinicaToUpdate;
        }
    }
}