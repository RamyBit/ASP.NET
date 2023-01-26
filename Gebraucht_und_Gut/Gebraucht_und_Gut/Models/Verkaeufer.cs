using System;
using System.Collections.Generic;

namespace Gebraucht_und_Gut.Models
{
    public partial class Verkaeufer
    {
        public Verkaeufer()
        {
            Rechnungs = new HashSet<Rechnung>();
        }

        public int VerkaeuferId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Rechnung> Rechnungs { get; set; }
    }
}
