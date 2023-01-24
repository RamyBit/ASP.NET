using System;
using System.Collections.Generic;

namespace WR3_1.Models
{
    public partial class Aggressor
    {
        public Aggressor()
        {
            Bedrohung = new HashSet<Bedrohung>();
        }

        public int AggressorId { get; set; }
        public string Name { get; set; }
        public string Spezialitaet { get; set; }

        public virtual ICollection<Bedrohung> Bedrohung { get; set; }
    }
}
