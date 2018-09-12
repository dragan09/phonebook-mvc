using phonebook.core.Data;
using phonebook.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace phonebook.Controllers
{
    public class HomeController : Controller
    {
        public IContactService contactService;

        public HomeController(IContactService ContactService) {
            contactService = ContactService;

            
        }

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Contact");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}