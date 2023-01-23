using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weltrettung_1.Models
{
    public class Repository
    {
        private static List<HeroResponse> responses = new List<HeroResponse>();
        public static IEnumerable<HeroResponse> Responses => responses;
        public static void AddResponse(HeroResponse response)
        {
            responses.Add(response);
        }
    }
}
