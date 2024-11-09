using DepiMvcTask1.Models;
using DepiMvcTask1.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;

namespace DepiMvcTask1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMyInfoRepository myInfoRepository;
        private readonly IServiceRepository serviceRepository;

        public HomeController(IMyInfoRepository myInfoRepository,IServiceRepository serviceRepository) 
        {
            this.myInfoRepository = myInfoRepository;
            this.serviceRepository = serviceRepository;
        }
        public IActionResult Index()
        {
            ViewBag.name = "Muhammed Hazem";
            ViewBag.role1 = "Developer";
            ViewBag.role2 = "Software Engineer";
            ViewBag.role3 = "Freelancer";
            ViewBag.role4 = "Analyst";
            return View("Index");
        }

        public IActionResult About()
        {
            List<MyInfo> myInfo = myInfoRepository.GetAll();
            return View(myInfo);
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
            List<Services> services= serviceRepository.GetAll();

            return View(services);
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
