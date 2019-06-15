using F1_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace F1_mvc.Controllers
{
    public class CircuitsController : Controller
    {
        internal static ModelF1 db = new ModelF1();

        // GET: Circuits
        public ActionResult Index()
        {
            return View(db.circuits.OrderBy(x => x.name).ToList());
        }

        public ActionResult Details(string circuitref)
        {
            return RedirectToAction("Index");
        }


    }
}