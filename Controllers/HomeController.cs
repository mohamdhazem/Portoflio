using DepiMvcTask1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DepiMvcTask1.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult About()
        {
            return View("About");
        }

        public IActionResult Resume()
        {
            return View("Resume");
        }

        public IActionResult Projects()
        {
            return View("Projects");
        }
        public IActionResult Services()
        {
            return View("Services");
        }
        public IActionResult Contact()
        {
            return View("Contact");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
