using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Anasayfa
    {
        public List<Doktor> Doktorlar { get; set; }
        public List<Doktor> Doktor2 { get; set; }
        public List<Polikinlik> Pol { get; set; }
        public List<Hasta> Hasta { get; set; }
        //public List<Doktor> DoktorlarGruplu { get; set; }
        public Dictionary<int, List<Doktor>> Doktor2Gruplu { get; set; }
        public List<Saatler> Saat{ get; set; }
        public List<Randevu> Randevular { get; set; }
    }
}
