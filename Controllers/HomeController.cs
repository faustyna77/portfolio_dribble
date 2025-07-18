using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Data;
using PortfolioApp.Models;
using System.Linq;
using System.Net.Http;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PortfolioApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly PortfolioDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(PortfolioDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }
        [HttpPost]
        public async Task<IActionResult> Refresh()
        {
            var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.GetAsync("https://rag-hscm.onrender.com/refresh");

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Dane odświeżone pomyślnie!";
            }
            else
            {
                TempData["Message"] = "Błąd podczas odświeżania danych.";
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index(string? question)
        {
            var projects = _context.Projects.ToList();
            ViewBag.Projects = projects;

            if (!string.IsNullOrEmpty(question))
            {
                var query = new QueryModel { Question = question };

                var httpClient = new HttpClient();
                var response = await httpClient.PostAsJsonAsync("https://rag-hscm.onrender.com/ask", query);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                    ViewBag.Answer = content["response"];
                }
                else
                {
                    ViewBag.Answer = "Błąd podczas komunikacji z API.";
                }
            }

            return View(projects); // ← to jest KLUCZOWE
        }




    }
}
