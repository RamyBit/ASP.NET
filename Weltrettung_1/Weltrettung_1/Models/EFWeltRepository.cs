using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weltrettung_1.Models;
namespace Weltrettung_1.Models
{
    public class EFWeltRepository : IWeltRepository
    {
        private WeltContext context;
        public EFWeltRepository(WeltContext ctx)
        {
            context = ctx;
        }

        public IQueryable<HeroResponse> HeroResponses => context.Heros;
        public IQueryable<AntiHeroResponse> AntiHeroResponses => context.AntiHeros;
        public IQueryable<Danger> Dangers => context.Dangers;

        public async Task<int> CreateHero (Response response)
        {
            HeroResponse hero = new HeroResponse
            {
                Vorname = response.Vorname,
                Nachname = response.Nachname,
                Email = response.Email,
                erwachsner = response.erwachsner
            };
            context.Heros.Add(hero);
            await context.SaveChanges();
            return hero.Held_id;

        }

        public async Task<int> CreateAntiHero(Response response)
        {
            AntiHeroResponse antiHero = new AntiHeroResponse
            {
                Aggressor_id = response.Aggressor_id,
                Nachname = response.Nachname,
                Vorname = response.Vorname,
                Spezialgebiet = response.Spezialgebiet
            };
            context.AntiHeros.Add(antiHero);
            await context.SaveChanges();
            return antiHero.Aggressor_id;

        }

        public async Task<int> CreateDanger(Response response)
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
            await context.SaveChanges();
            return danger.BedrohungsId;

        }
    }

   
}
