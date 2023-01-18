using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Kayak", Description = "A boat for one person",
                        Catagory = "Watersports", Price = 275
                    },
                    new Product
                    {
                        Name = "Lifejacket",
                        Description = "Protective and fashionable",
                        Catagory = "Watersports", Price = 48.95m
                    },
                    new Product
                    {
                        Name = "Soccer Ball",
                        Description = "FIFA-Approved size and weight",
                        Catagory = "Watersports", Price = 48.95m
                    },
                    new Product
                    {
                        Name ="Corner Flags",
                        Description = "Give your playing field a professional touch",
                        Catagory = "Soccer", Price = 34.95m
                    },
                    new Product
                    {
                        Name = "Stadium",
                        Description = "Flat-packed 35,000-seat stadium",
                        Catagory = "Soccer", Price = 78500
                    },
                    new Product
                    {
                        Name = "Thinking Cap",
                        Description = "Improve brain efficiency by 75%",
                        Catagory = "Chess", Price = 16
                    },
                    new Product
                    {
                        Name = "Unsteady Chair",
                        Description = "Secretly give your opponent a disadvantage",
                        Catagory = "Chess", Price = 29.95m
                    },
                    new Product
                    {
                        Name = "Human Chesss Board",
                        Description = "A fun game for the family ",
                        Catagory = "Chess", Price=75
                    },
                    new Product
                    {
                        Name = "Bling-Bling King",
                        Description = "Gold-plated, diamond-studded king",
                        Catagory = "Chess", Price = 1200
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
