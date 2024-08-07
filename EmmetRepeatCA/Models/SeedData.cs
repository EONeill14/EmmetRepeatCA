using EmmetRepeatCA.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace EmmetRepeatCA.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<StoreDbContext>();

                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Vinyls.Any())
                {
                    var artist1 = new Artist
                    {
                        Name = "Noel Gallagher",
                        Bio = "Former Oasis lead guitarist and vocalist."
                    };

                    context.Artists.Add(artist1);

                    context.Vinyls.AddRange(
                        new Vinyl
                        {
                            Title = "Noel Gallagher's High Flying Birds",
                            Description = "First solo album",
                            Genre = "Rock N Roll",
                            Price = 100,
                            ReleaseDate = new DateTime(2011, 10, 17),
                            Artist = artist1
                        },
                        new Vinyl
                        {
                            Title = "Chasing Yesterday",
                            Description = "Second solo album",
                            Genre = "Rock N Roll",
                            Price = 90,
                            ReleaseDate = new DateTime(2015, 2, 25),
                            Artist = artist1
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
