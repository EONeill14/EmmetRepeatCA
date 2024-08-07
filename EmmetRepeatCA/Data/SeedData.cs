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

                    var artist2 = new Artist
                    {
                        Name = "Liam Gallagher",
                        Bio = "Former Oasis lead vocalist."
                    };

                    var artist3 = new Artist
                    {
                        Name = "Oasis",
                        Bio = "Iconic British rock band."
                    };

                    var artist4 = new Artist
                    {
                        Name = "Kasabian",
                        Bio = "British rock band from Leicester."
                    };

                    var artist5 = new Artist
                    {
                        Name = "Stereophonics",
                        Bio = "Welsh rock band."
                    };

                    var artist6 = new Artist
                    {
                        Name = "Arctic Monkeys",
                        Bio = "British indie rock band."
                    };

                    context.Artists.AddRange(artist1, artist2, artist3, artist4, artist5, artist6);

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
                        },
                        new Vinyl
                        {
                            Title = "As You Were",
                            Description = "First solo album",
                            Genre = "Rock",
                            Price = 80,
                            ReleaseDate = new DateTime(2017, 10, 6),
                            Artist = artist2
                        },
                        new Vinyl
                        {
                            Title = "Why Me? Why Not.",
                            Description = "Second solo album",
                            Genre = "Rock",
                            Price = 85,
                            ReleaseDate = new DateTime(2019, 9, 20),
                            Artist = artist2
                        },
                        new Vinyl
                        {
                            Title = "(What's the Story) Morning Glory?",
                            Description = "Second studio album",
                            Genre = "Britpop",
                            Price = 120,
                            ReleaseDate = new DateTime(1995, 10, 2),
                            Artist = artist3
                        },
                        new Vinyl
                        {
                            Title = "Definitely Maybe",
                            Description = "Debut studio album",
                            Genre = "Britpop",
                            Price = 110,
                            ReleaseDate = new DateTime(1994, 8, 29),
                            Artist = artist3
                        },
                        new Vinyl
                        {
                            Title = "West Ryder Pauper Lunatic Asylum",
                            Description = "Third studio album",
                            Genre = "Indie Rock",
                            Price = 95,
                            ReleaseDate = new DateTime(2009, 6, 5),
                            Artist = artist4
                        },
                        new Vinyl
                        {
                            Title = "Velociraptor!",
                            Description = "Fourth studio album",
                            Genre = "Indie Rock",
                            Price = 90,
                            ReleaseDate = new DateTime(2011, 9, 16),
                            Artist = artist4
                        },
                        new Vinyl
                        {
                            Title = "Performance and Cocktails",
                            Description = "Second studio album",
                            Genre = "Rock",
                            Price = 85,
                            ReleaseDate = new DateTime(1999, 3, 8),
                            Artist = artist5
                        },
                        new Vinyl
                        {
                            Title = "Just Enough Education to Perform",
                            Description = "Third studio album",
                            Genre = "Rock",
                            Price = 80,
                            ReleaseDate = new DateTime(2001, 4, 17),
                            Artist = artist5
                        },
                        new Vinyl
                        {
                            Title = "Whatever People Say I Am, That's What I'm Not",
                            Description = "Debut studio album",
                            Genre = "Indie Rock",
                            Price = 100,
                            ReleaseDate = new DateTime(2006, 1, 23),
                            Artist = artist6
                        },
                        new Vinyl
                        {
                            Title = "AM",
                            Description = "Fifth studio album",
                            Genre = "Indie Rock",
                            Price = 95,
                            ReleaseDate = new DateTime(2013, 9, 9),
                            Artist = artist6
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
