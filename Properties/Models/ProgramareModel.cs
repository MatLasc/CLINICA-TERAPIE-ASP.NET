using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAWPROIECTR.Models
{
    public class ProgramareModel
    {
        public int Id { get; set; }
        public int Plata { get; set; }

        public DateTime Data { get; set; }

        public int ClientId { get; set; } 
        public int TerapeutId { get; set; }

    }
}