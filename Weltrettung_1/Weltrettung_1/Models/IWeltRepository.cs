using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weltrettung_1.Models;

namespace Weltrettung_1.Models
{
    public interface IWeltRepository
    {
        IQueryable<HeroResponse> HeroResponses { get; }
        IQueryable<AntiHeroResponse> AntiHeroResponses { get; }
        IQueryable<Danger> Dangers { get; }
        Task<int> CreateHero(Response response);
        Task<int> CreateAntiHero(Response response);
        Task<int> CreateDanger(Response response);
    }
}
