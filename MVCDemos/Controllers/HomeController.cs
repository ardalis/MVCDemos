using System;
using Microsoft.AspNetCore.Mvc;
using MVCDemos.Models;

namespace MVCDemos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            try
            {
                throw new Exception("Planned exception.");
            }
            catch
            {
                return View("Error");
            }
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            var contactViewModel = new ContactViewModel()
            {
                Name = "Steve Smith",
                BlogName = "Ardalis.com",
                BlogUrl = "http://ardalis.com",
                Twitter = "@ardalis"
            };
            return View(contactViewModel);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
