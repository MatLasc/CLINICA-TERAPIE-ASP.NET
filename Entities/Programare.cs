using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAWPROIECTR.Entities
{
    public class Programare
    {
  
        public int Id { get; set; }
        public int Plata { get; set; }

        public DateTime Data { get; set; }

        public int ClientId { get; set; } 
        public int TerapeutId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Terapeut Terapeut { get; set; }


    }
}