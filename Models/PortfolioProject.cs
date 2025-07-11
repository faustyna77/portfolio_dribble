﻿namespace PortfolioApp.Models
{
    public class PortfolioProject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ProjectLink { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
