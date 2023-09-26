using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Doktor
    {
        public int DoktorId { get; set; }
        public string DoktorTc { get; set; }
        public string DoktorAdi { get; set; }
        public string DoktorSoyadi { get; set; }
        public int PolikinlikId { get; set; }
        public Polikinlik Polikinlik { get; set; }
        public ICollection<Hasta> Hastalar { get; set; }
    }
}
