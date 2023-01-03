using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarenkorbApplikation.Models;

namespace WarenkorbApplikation.Views {
    class EingabeArtikel {
        public static string AuswahlArtikel ( ) {
            Console.WriteLine ( "Gib einen Artikel an: ");
            string artnr = Console.ReadLine ( );
            return artnr;
        }

        public static int AnzahlArtikel ( ) {
            int anzahl = 0;
            Console.WriteLine ( "Gib die Anzahl an: " );
            anzahl = Convert.ToInt32(Console.ReadLine ( ));
            return anzahl;
        }
    }
}
