using System;
using System.Collections.Generic;

namespace Gebraucht_und_Gut.Models
{
    public partial class Kunde
    {
        public Kunde()
        {
            Rechnungs = new HashSet<Rechnung>();
        }

        public int KundeId { get; set; }
        public string Name { get; set; } = null!;
        public string Vorname { get; set; } = null!;

        public virtual ICollection<Rechnung> Rechnungs { get; set; }
    }
}
