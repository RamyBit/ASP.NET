using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weltrettung_1.Models;


namespace Weltrettung_1.Models
{
    public class WeltContext : DbContext
    {
        public WeltContext(DbContextOptions<WeltContext> options): base(options)
        {

        }
        public DbSet<HeroResponse> Heros { get; set; }
        public DbSet<AntiHeroResponse> AntiHeros { get; set; }
        public DbSet<Danger> Dangers { get; set; }
        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
