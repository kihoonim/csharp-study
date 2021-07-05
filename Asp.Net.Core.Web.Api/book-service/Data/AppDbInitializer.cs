using book_service.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_service.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                    new Book
                    {
                        Title = "1st Book Title",
                        Description = "1st Book Desc",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        Author = "First Author",
                        CoverUrl = "https....",
                        DateAdded = DateTime.Now
                    },
                    new Book
                    {
                        Title = "2nd Book Title",
                        Description = "2nd Book Desc",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        Author = "Second Author",
                        CoverUrl = "https....",
                        DateAdded = DateTime.Now
                    });

                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product
                        {
                            Name = "Learning ASP.NET Core",
                            Description = "A best-selling book covering the fundamentals of ASP.NET Core",
                            IsOnSale = true,
                        },
                        new Product
                        {
                            Name = "Learning EF Core",
                            Description = "A best-selling book covering the fundamentals of Entity Framework Core",
                            IsOnSale = true,
                        },
                        new Product
                        {
                            Name = "Learning .NET Standard",
                            Description = "A best-selling book covering the fundamentals of .NET Standard",
                        },
                        new Product
                        {
                            Name = "Learning .NET Core",
                            Description = "A best-selling book covering the fundamentals of .NET Core",
                        },
                        new Product
                        {
                            Name = "Learning C#",
                            Description = "A best-selling book covering the fundamentals of C#",
                        });
                    context.SaveChanges();
                }
            }
        }
    }
}
