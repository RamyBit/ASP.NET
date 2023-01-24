using System;
using System.Collections.Generic;

namespace WR3_1.Models
{
    public partial class Held
    {
        public Held()
        {
            Bedrohung = new HashSet<Bedrohung>();
        }

        public int HeldId { get; set; }
        public string Name { get; set; }
        public string Beruf { get; set; }

        public virtual ICollection<Bedrohung> Bedrohung { get; set; }
    }
}
