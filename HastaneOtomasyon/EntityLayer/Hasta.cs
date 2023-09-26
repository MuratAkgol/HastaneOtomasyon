using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Hasta
    {
        public int HastaId { get; set; }
        public string HastaTc { get; set; }
        public string HastaAdi { get; set; }
        public string HastaSoyadi { get; set; }
        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }
    }
}
