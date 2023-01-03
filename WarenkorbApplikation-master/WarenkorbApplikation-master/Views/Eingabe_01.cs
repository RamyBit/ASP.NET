
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarenkorbApplikation.Views {
    class Eingabe_01 {

        public static int e_01 ( ) {
            Console.WriteLine ( "Gib eine Angebotsnummer an:" );
            int nr = Convert.ToInt32 ( Console.Read ( ) );
            return nr;
        }
    }
}
