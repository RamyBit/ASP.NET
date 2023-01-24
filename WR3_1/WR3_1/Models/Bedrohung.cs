using System;
using System.Collections.Generic;

namespace WR3_1.Models
{
    public partial class Bedrohung
    {
        public int BedrohungId { get; set; }
        public string Name { get; set; }
        public bool Akut { get; set; }
        public int? HeldId { get; set; }
        public int? AggressorId { get; set; }

        public virtual Aggressor Aggressor { get; set; }
        public virtual Held Held { get; set; }
    }
}
