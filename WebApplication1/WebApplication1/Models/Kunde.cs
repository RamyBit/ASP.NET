using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Kunde
    {
        public Kunde()
        {
            Besuches = new HashSet<Besuch>();
        }

        public int KundeId { get; set; }
        public string Name { get; set; } = null!;
        public bool Stammkd { get; set; }
        public string Strasse { get; set; } = null!;
        public string Hausnummer { get; set; } = null!;
        public string Plz { get; set; } = null!;
        public string Stadt { get; set; } = null!;

        public virtual ICollection<Besuch> Besuches { get; set; }
    }
}
