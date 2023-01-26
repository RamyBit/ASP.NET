using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Gebiet
    {
        public int GebietId { get; set; }
        public string Name { get; set; } = null!;

        public virtual Consultant? Consultant { get; set; }
    }
}
