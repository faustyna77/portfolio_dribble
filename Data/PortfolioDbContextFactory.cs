﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PortfolioApp.Data
{
    public class PortfolioDbContextFactory : IDesignTimeDbContextFactory<PortfolioDbContext>
    {
        public PortfolioDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PortfolioDbContext>();
            optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));
           

            return new PortfolioDbContext(optionsBuilder.Options);
        }
    }
}
