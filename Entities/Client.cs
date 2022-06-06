using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAWPROIECTR.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Nume { get; set; }

        public string Prenume { get; set; }

        public virtual ICollection<Programare> Programari { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}