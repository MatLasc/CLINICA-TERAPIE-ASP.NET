using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAWPROIECTR.Entities
{
    public class Clinica
    {
      
        public int Id { get; set; }
        public string Oras { get; set; }

        public string Adresa { get; set; }

        public ICollection<Terapeut> Terapeuti { get; set; }

    }
}
