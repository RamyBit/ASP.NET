using System;
using System.Collections.Generic;

namespace Gebraucht_und_Gut.Models
{
    public partial class Rechnung
    {
        public Rechnung()
        {
            Fahrzeugs = new HashSet<Fahrzeug>();
        }

        public int ReId { get; set; }
        public DateTime? Datum { get; set; }
        public int? KundeId { get; set; }
        public int? VerkaeuferId { get; set; }

        public virtual Kunde? Kunde { get; set; }
        public virtual Verkaeufer? Verkaeufer { get; set; }
        public virtual ICollection<Fahrzeug> Fahrzeugs { get; set; }
    }
}
