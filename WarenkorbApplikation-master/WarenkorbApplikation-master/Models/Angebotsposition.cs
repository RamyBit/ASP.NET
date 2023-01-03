using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarenkorbApplikation.Models {
    class Angebotsposition {
        public int Angebot_id { get; set; }
        public int Artikel_ID { get; set; }
        public double Preis { get; set; }
        public int Anzahl { get; set; }
        public Artikel Artikel { get; set; }
    }
}
