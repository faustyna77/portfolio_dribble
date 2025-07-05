using PortfolioApp.Models;
using System;

namespace PortfolioApp.Data
{
    public static class DbInitializer
    {
        public static void Seed(PortfolioDbContext context)
        {
            if (context.Projects.Any()) return;

            var projects = new PortfolioProject[]
            {
                new PortfolioProject
                {
                    Title = "Moje portfolio",
                    Description = "Projekt portfolio zrealizowany w ASP.NET Core",
                    ShortDescription = "Portfolio ASP.NET",
                    Content = "<p>To moje osobiste portfolio stworzone w ASP.NET Core MVC.</p>",
                    ImageUrl = "https://example.com/image1.png",
                    VideoEmbedCode = "",
                    ProjectLink = "https://github.com/twojprofil/portfolio",
                    Tags = "C#, ASP.NET, Portfolio",
                    Category = "Portfolio",
                    Slug = "moje-portfolio",
                    CreatedAt = DateTime.UtcNow
                },
                new PortfolioProject
                {
                    Title = "Inny projekt",
                    Description = "Opis innego ciekawego projektu",
                    ShortDescription = "Projekt z JS",
                    Content = "<p>Opis projektu front-endowego.</p>",
                    ImageUrl = "https://example.com/image2.png",
                    VideoEmbedCode = "",
                    ProjectLink = "https://github.com/twojprofil/inny-projekt",
                    Tags = "JavaScript, Vue, Design",
                    Category = "Blog",
                    Slug = "inny-projekt",
                    CreatedAt = DateTime.UtcNow
                }
            };

            context.Projects.AddRange(projects);
            context.SaveChanges();
        }
    }
}
