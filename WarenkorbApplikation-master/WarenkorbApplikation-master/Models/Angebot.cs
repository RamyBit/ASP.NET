using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarenkorbApplikation.Models {
    class Angebot {
        public int Angebot_ID { get; set; }
        public DateTime Datum { get; set; }
        private List<Angebotsposition> listePositionen = new List<Angebotsposition> ( );

        public Angebot ( int angebotsid) {
            Angebot_ID = angebotsid;
            Datum = DateTime.Now;
        }

        public void AddArtikel ( Artikel artikel, int anzahl) {
            listePositionen.Add ( new Angebotsposition ( ) {
                Artikel = artikel ,
                Anzahl = anzahl ,
                Artikel_ID = artikel.Artikel_ID ,
                Angebot_id = this.Angebot_ID ,
                Preis = artikel.Preis
            } );
        }

        private double RechnePositionswert ( int position ) {
            double wert = 0;
            wert = listePositionen [ position ].Anzahl * 
                listePositionen [ position ].Preis;
            return wert;
        }

        public double BerechneEndbetrag ( ) {
            double wert = 0;

            for ( int i = 0 ; i < listePositionen.Count ; i++ ) {
                wert += RechnePositionswert(i);
            }

            return wert;
        }

    }
}
