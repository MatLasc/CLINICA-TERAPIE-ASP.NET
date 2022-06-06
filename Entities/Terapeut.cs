using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAWPROIECTR.Entities
{
    public class Terapeut
    {
        public int Id { get; set; }
        public string Nume { get; set; }

        public string Prenume { get; set; }

        public int? ClinicaId { get; set; }
        public virtual Clinica Clinica { get; set; }
        public virtual ICollection<Programare> Programari { get; set; }


    }
}