using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcGuitars10.Data;
using System;
using System.Linq;

namespace MvcGuitars10.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcGuitars10Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcGuitars10Context>>()))
            {
                // Look for any movies.
                if (context.Guitars.Any())
                {
                    return;   // DB has been seeded
                }

                context.Guitars.AddRange(

                    new Guitars
                    {
                        GuitarBrand = "Fender",
                        GuitarModel = "Stratocaster",
                        IssueYear = 1955,
                        Price = 780.99M
                    },
                    new Guitars
                    {
                        GuitarBrand = "Fender",
                        GuitarModel = "Telecaster",
                        IssueYear = 1945,
                        Price = 885.99M
                    },
                    new Guitars
                    {
                        GuitarBrand = "Gibson",
                        GuitarModel = "Les Paul",
                        IssueYear = 1954,
                        Price = 415.99M
                    },
                    new Guitars
                    {
                        GuitarBrand = "Ibanez",
                        GuitarModel = "Iceman",
                        IssueYear = 1985,
                        Price = 499.99M
                    }



                );
                context.SaveChanges();
            }
        }
    }
}