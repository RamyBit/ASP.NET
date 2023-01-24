using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weltrettung_1.Models
{
    public class Danger
    {
        public int BedrohungsId { get; set; }
        public string Bedrohungsname { get; set; }
        public bool? Existiert { get; set; }
        public int Held_id { get; set; }
        public int Aggressor_id { get; set; }
    }
}
