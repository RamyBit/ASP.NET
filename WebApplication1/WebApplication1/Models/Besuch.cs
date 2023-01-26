using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Besuch
    {
        public int BesuchId { get; set; }
        public string Beschreibung { get; set; } = null!;
        public DateTime Datum { get; set; }
        public int? ConsultantId { get; set; }
        public int KundeId { get; set; }

        public virtual Consultant? Consultant { get; set; }
        public virtual Kunde Kunde { get; set; } = null!;
    }
}
