using Microsoft.AspNetCore.Mvc;
using selida.Data;
using selida.Models;
using System.Diagnostics;

namespace selida.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly SelidaDbContext selidaDbContext;

        public HomeController(ILogger<HomeController> logger, SelidaDbContext selidaDbContext)
        {
            _logger = logger;
            this.selidaDbContext = selidaDbContext;
        }

        [HttpGet]
        // GET: Latest Posts

        public IActionResult Index()
        {
            var posts = selidaDbContext.BlogPosts.ToList();
            return View(posts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}