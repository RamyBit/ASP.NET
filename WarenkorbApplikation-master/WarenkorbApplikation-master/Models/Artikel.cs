using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarenkorbApplikation.Models {
    class Artikel {
        public int Artikel_ID { get; set; }
        public string Name { get; set; }
        public double Preis { get; set; }
        public string Mengeneinheit { get; set; }
    }
}
