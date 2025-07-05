namespace PortfolioApp.Controllers
{
    using global::PortfolioApp.Data;
    using global::PortfolioApp.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
   

    namespace PortfolioApp.Controllers
    {

       
        public class PortfolioController : Controller
        {
            private readonly PortfolioDbContext _context;

            public PortfolioController(PortfolioDbContext context)
            {
                _context = context;
            }
            [HttpGet("Portfolio/{slug}")]
            public IActionResult DetailsBySlug(string slug)
            {
                var project = _context.Projects.FirstOrDefault(p => p.Slug == slug);
                if (project == null)
                    return NotFound();

                return View("Details", project); // używa widoku Details.cshtml
            }

            [Authorize]
            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }
            

            [HttpPost]
            public IActionResult Create(PortfolioProject project)
            {
                if (ModelState.IsValid)
                {
                    _context.Projects.Add(project);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }

                return View(project);
            }
           

            public IActionResult Details(int id)
            {
                var project = _context.Projects.FirstOrDefault(p => p.Id == id);
                if (project == null)
                {
                    return NotFound();
                }

                return View(project);
            }

        }
    }

}
