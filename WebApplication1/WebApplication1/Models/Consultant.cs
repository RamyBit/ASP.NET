using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Consultant
    {
        public Consultant()
        {
            Besuches = new HashSet<Besuch>();
        }

        public int ConsultantId { get; set; }
        public string Name { get; set; } = null!;
        public int GebietId { get; set; }

        public virtual Gebiet Gebiet { get; set; } = null!;
        public virtual ICollection<Besuch> Besuches { get; set; }
    }
}
