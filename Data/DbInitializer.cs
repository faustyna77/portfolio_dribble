using PortfolioApp.Models;
using System;
using System.Linq;

namespace PortfolioApp.Data
{
    public static class DbInitializer
    {
        public static void Seed(PortfolioDbContext context)
        {
            // Jeśli istnieją rekordy, pomiń
            if (context.Projects.Any()) return;

            var projects = new PortfolioProject[]
            {
                new PortfolioProject
                {
                    Title = "Moje portfolio",
                    Description = "Projekt portfolio zrealizowany w ASP.NET Core",
                    ImageUrl = "https://example.com/image1.png",
                    ProjectLink = "https://github.com/twojprofil/portfolio",
                    CreatedAt = DateTime.UtcNow
                },
                new PortfolioProject
                {
                    Title = "Inny projekt",
                    Description = "Opis innego ciekawego projektu",
                    ImageUrl = "https://example.com/image2.png",
                    ProjectLink = "https://github.com/twojprofil/inny-projekt",
                    CreatedAt = DateTime.UtcNow
                }
            };

            context.Projects.AddRange(projects);
            context.SaveChanges();
        }
    }
}
