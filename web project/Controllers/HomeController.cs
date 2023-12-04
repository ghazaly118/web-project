using Elfie.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq; // Import LINQ for .ToList() method
using web_project.Data;
using web_project.Models;

namespace web_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly web_projectContext _context; // Update the type of _context here

        public HomeController(ILogger<HomeController> logger, web_projectContext context) // Update the constructor parameter
        {
            _logger = logger;
            _context = context; // Assign the injected context to the private variable
        }

        // Other actions...

        public IActionResult Menu()
        {
            var menus = _context.Menu.ToList(); // Fetching a list of Menu items from the database
            return View(menus); // Passing the list of Menu items to the view
        }

        // Other actions...

    


public IActionResult Index()
        {
            return View();
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
