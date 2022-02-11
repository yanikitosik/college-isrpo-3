using _2РАБОТА.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _2РАБОТА.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Moning" : "Good Afternoon";
            return View();

        }
        [HttpGet]
        public IActionResult ContactForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FormContact(Contact contact)
        {
            using (ContactsContext db = new ContactsContext())
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
            }
            return View("ContactAdded", contact);

        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ContactsList()
        {
            using (ContactsContext db = new ContactsContext())
            {
                ViewBag.Contacts = db.Contacts.ToList();
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
