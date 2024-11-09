using DepiMvcTask1.Data;
using Microsoft.AspNetCore.Mvc;

namespace DepiMvcTask1.Controllers
{
    public class ContactController : Controller
    {
        private readonly PortflioContext portflioContext;

        public ContactController(PortflioContext portflioContext) 
        {
            this.portflioContext = portflioContext;
        }

        [HttpGet]
        public IActionResult AddContactData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveContactData(ContactData contactInfo)
        {
            if(ModelState.IsValid)
            {
                portflioContext.contactData.Add(contactInfo);
                portflioContext.SaveChanges();
            }
            return RedirectToAction("AddContactData");
        }
    }
}
