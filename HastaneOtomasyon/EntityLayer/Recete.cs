using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Recete
    {
        public int ReceteId { get; set; }
        public string ReceteIcerik { get; set; }
        public int HastaId { get; set; }
        public Hasta Hasta { get; set; }
    }
}
