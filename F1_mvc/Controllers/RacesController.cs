using F1_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace F1_mvc.Controllers
{
    public class RacesController : Controller
    {
        internal static ModelF1 db = new ModelF1();

        // GET: Races
        public ActionResult Index()
        {
            var l = db.races.OrderBy(x => x.date).ToList();

            return View(l);
        }
    }
}