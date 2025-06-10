using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcChair.Data;
using System;
using System.Linq;

namespace MVCChair.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcChairContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcChairContext>>()))
            {
                // Look for any chairs.
                if (context.Chair.Any())
                {
                    return;   // DB has been seeded
                }

                context.Chair.AddRange(
                    new Chair
                    {
                        Brand = "STRUCTUBE",
                        Type = "Lounge",
                        Color = "Grey",
                        Material = "Fabric",
                        Capacity = 125,
                        Price = 79.99M,
                        Rating = 4
                    },
                    new Chair
                    {
                        Brand = "IKEA",
                        Type = "Office Chair",
                        Color = "Black",
                        Material = "Mesh",
                        Capacity = 120,
                        Price = 129.99M,
                        Rating = 4
                    },
                    new Chair
                    {
                        Brand = "Herman Miller",
                        Type = "Ergonomic Chair",
                        Color = "Gray",
                        Material = "Fabric",
                        Capacity = 150,
                        Price = 999.99M,
                        Rating = 5
                    },
                    new Chair
                    {
                        Brand = "Staples",
                        Type = "Gaming Chair",
                        Color = "Red/Black",
                        Material = "PU Leather",
                        Capacity = 140,
                        Price = 249.99M,
                        Rating = 4
                    },
                    new Chair
                    {
                        Brand = "Wayfair",
                        Type = "Dining Chair",
                        Color = "White",
                        Material = "Wood",
                        Capacity = 100,
                        Price = 89.99M,
                        Rating = 3
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
