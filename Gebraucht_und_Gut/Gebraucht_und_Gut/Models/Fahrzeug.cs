using System;
using System.Collections.Generic;

namespace Gebraucht_und_Gut.Models
{
    public partial class Fahrzeug
    {
        public int FzId { get; set; }
        public string Marke { get; set; } = null!;
        public string Typ { get; set; } = null!;
        public decimal? Preis { get; set; }
        public int? ReId { get; set; }

        public virtual Rechnung? Re { get; set; }
    }
}
