using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WhatInHere.Data;
using System;
using System.Linq;
using WhatInHere.Models;

namespace WhatInHere.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Chemicals.Any())
                {
                    return;   // DB has been seeded
                }

                context.Chemicals.AddRange(
                    new Chemicals
                    {
                        Chemical = "Pyridoxine",
                        Effects = "Chemical name for Vitamin B6",
                        Natural = "Unnatural",
                        Source = "https://azchemistry.com/chemicals-in-food"
                    },

                   new Chemicals
                   {
                       Chemical = "Silicon dioxide",
                       Effects = "None",
                       Natural = "Natural",
                       Source = "https://azchemistry.com/chemicals-in-food"
                   },

                   new Chemicals
                   {
                       Chemical = "Aspartame",
                       Effects = "headaches, dizziness, stomach problems, and blurred vision.",
                       Natural = "Unnatural",
                       Source = "https://azchemistry.com/chemicals-in-food"
                   },

                    new Chemicals
                    {
                        Chemical = "Tertiary butylhydroquinone(TBHQ)",
                        Effects = "stomach tumor and other health issues",
                        Natural = "Unnatural",
                        Source = "https://azchemistry.com/chemicals-in-food"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}