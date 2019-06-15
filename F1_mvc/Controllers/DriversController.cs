using F1_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace F1_mvc.Controllers
{
    public class DriversController : Controller
    {
        internal static ModelF1 db = new ModelF1();

        // GET: Drivers
        public ActionResult Index()
        {
            return View(db.drivers.ToList());
        }


        public ActionResult Details(string id)
        {
            if (id == null || id == "")
                throw new HttpException(404, "The driver "+id+" requested is not in the database.");

            drivers r = db.drivers.Where(x => x.driverRef == id).FirstOrDefault();
            if (r == null)
                throw new HttpException(404, "The driver "+id+" requested is not in the database.");

            ViewBag.Title = r.forename + " " + r.surname;

            return View(r);
        }

    }
}