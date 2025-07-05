using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data;
using PortfolioApp.Models;
using System.Linq;

namespace PortfolioApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly PortfolioDbContext _context;

        public HomeController(PortfolioDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var projects = _context.Projects.ToList();
            return View(projects);
        }
    }
}
