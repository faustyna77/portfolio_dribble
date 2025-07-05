using Microsoft.EntityFrameworkCore;
using PortfolioApp.Models;

namespace PortfolioApp.Data
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
        {
        }

        public PortfolioDbContext() { } // Dla EF Core CLI

        public DbSet<PortfolioProject> Projects { get; set; }
    }
}
