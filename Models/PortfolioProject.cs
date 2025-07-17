using System;
using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Models
{
    public class PortfolioProject
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = default!;

        [Required]
        public string Description { get; set; } = default!;

        [Required]
        public string ProjectLink { get; set; } = default!;

        public string? ImageUrl { get; set; }
        public string? VideoUrl { get; set; }
        public string? VideoEmbedCode { get; set; }

        public string? ShortDescription { get; set; }
        public string? Content { get; set; }

        public string? Tags { get; set; }
        public string? Category { get; set; }

        public string? Slug { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int ViewCount { get; set; } = 0;


    }
}
