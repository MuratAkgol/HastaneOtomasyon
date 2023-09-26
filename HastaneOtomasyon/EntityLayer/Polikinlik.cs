using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Polikinlik
    {
        public int PolikinlikId { get; set; }
        public string PolikinlikAdi { get; set; }
        public ICollection<Doktor> Doktorlar { get; set; }
    }
}
