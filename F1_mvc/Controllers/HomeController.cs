using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using F1_mvc.Models;

namespace F1_mvc.Controllers
{
    public class HomeController : Controller
    {
        private ModelF1 db = new ModelF1();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }


        public ActionResult Seasons()
        {
            return View(db.seasons.ToList());
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        
    }
}