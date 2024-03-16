using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class Kategori
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
    }
}
