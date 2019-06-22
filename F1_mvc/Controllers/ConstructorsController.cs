using F1_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace F1_mvc.Controllers
{
    public class ConstructorsController : Controller
    {
        internal static readonly ModelF1 db = new ModelF1();
        
        // GET: Constructors
        public ActionResult Index()
        {
            ViewBag.Title = "Constructors";
            return View();
        }

        
        public PartialViewResult GridConstructors()
        {
            return PartialView("_GridConstructors", db.constructors.OrderBy(x => x.name).ToList());
        }
    }
}