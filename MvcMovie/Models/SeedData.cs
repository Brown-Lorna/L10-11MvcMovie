using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "Emma Smith: My Story",
                         ReleaseDate = DateTime.Parse("2008-4-11"),
                         Genre = "Biography",
                         Price = 14.99M,
                         Rating = "PG"
                     },

                     new Movie
                     {
                         Title = "Forever Strong",
                         ReleaseDate = DateTime.Parse("2008-9-26"),
                         Genre = "Drama",
                         Price = 19.99M,
                         Rating = "PG-13"
                     },

                     new Movie
                     {
                         Title = "Once I Was a Beehive",
                         ReleaseDate = DateTime.Parse("2015-8-14"),
                         Genre = "Comedy",
                         Price = 9.99M,
                         Rating = "PG"
                     },

                     new Movie
                     {
                         Title = "The Errand of Angels",
                         ReleaseDate = DateTime.Parse("2008-8-22"),
                         Genre = "Drama",
                         Price = 14.99M,
                         Rating = "PG"
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
