using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weltrettung_1.Models
{
    public class HeroResponse
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Email { get; set; }
        public string Feahigkeit { get; set; }
        public bool? erwachsner { get; set; }
    }
}
