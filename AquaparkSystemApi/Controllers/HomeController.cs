using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AquaparkSystemApi.Controllers
{
    public class HomeController : Controller
    {
        AquaparkDbContext dbContext = new AquaparkDbContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
