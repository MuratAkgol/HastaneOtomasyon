using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class RandevuViewModel
    {
        public int RandevuId { get; set; }
        public string Saat { get; set; }
        public int Doktor { get; set; }
        public string HastaAdiSoyadi { get; set; }
        public string DoktorAdiSoyadi { get; set; }
    }
}
