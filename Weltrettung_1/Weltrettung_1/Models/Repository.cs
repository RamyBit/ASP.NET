using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weltrettung_1.Models
{
    public class Repository
    {
        //private static List<HeroResponse> responses = new List<HeroResponse>();
        //public static IEnumerable<HeroResponse> Responses => responses;
        //public static void AddResponse(HeroResponse response)
        //{
        //    responses.Add(response);
        //}
       static public void AddHero(WeltContext context, Response response)
        {
            HeroResponse hero = new HeroResponse
            {
                Vorname = response.Vorname,
                Nachname = response.Nachname,
                Email = response.Email,
                erwachsner = response.erwachsner
            };
            context.Heros.Add(hero);
        }
       static public void AddAntiHero(WeltContext context, Response response)
        {
            AntiHeroResponse antiHero = new AntiHeroResponse
            {
                Aggressor_id = response.Aggressor_id,
                Nachname = response.Nachname,
                Vorname = response.Vorname,
                Spezialgebiet = response.Spezialgebiet
            };
            context.AntiHeros.Add(antiHero);
        }

       static public void Danger(WeltContext context, Response response)
        {
            Danger danger = new Danger
            {
                BedrohungsId = response.BedrohungsId,
                Bedrohungsname = response.Bedrohungsname,
                Existiert = response.Existiert,
                Held_id = response.Held_id,
                Aggressor_id = response.Aggressor_id
            };
            context.Dangers.Add(danger);
        }
    }


}
