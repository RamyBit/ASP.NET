using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weltrettung_1.Models
{
    public class Response
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Email { get; set; }
        public string Feahigkeit { get; set; }
        public bool? erwachsner { get; set; }
        public int Aggressor_id { get; set; }
        public string Spezialgebiet { get; set; }
        public int BedrohungsId { get; set; }
        public string Bedrohungsname { get; set; }
        public bool? Existiert { get; set; }
        public int Held_id { get; set; }

        

    }
}
