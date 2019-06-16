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
            var r = GetDriverByRef(id);
            if(r == null)
                throw new HttpException(404, "The driver "+id+" requested is not in the database.");


                ViewBag.Title = r.forename + " " + r.surname;

            return View(r);
        }

        public PartialViewResult Statistics(int id)
        {
            var r = GetDriverByRef(id);
            if(r == null)
                throw new HttpException(404, "The driver "+id+" requested is not in the database.");

            List<object> stats = new List<object>();
            stats.Add(r);

            var seasons = Classes.Queries.GetSeasonsCount(db, id);
            stats.Add(seasons);

            int races = db.results.Where(x => x.driverId == id).Count();
            stats.Add(races);

            int poles = db.results.Where(x => x.driverId == id && x.grid == 1).Count();
            stats.Add(poles);

            int fl = Classes.Queries.GetFastestLapCount(db, id);
            stats.Add(fl);

            int vic = db.results.Where(x => x.driverId == id && x.position == 1).Count();
            stats.Add(vic);
            
            int cham = Classes.Queries.GetChampionshipCount(db, id);
            stats.Add(cham);

            return PartialView("_Statistics", stats);
        }
        
        public PartialViewResult Races(string id)
        {
            var dri = GetDriverByRef(id);
            if (dri == null)
                throw new HttpException(404, "The driver " + id + " requested is not in the database.");
            
            return PartialView("_Testing");
        }

        

        internal static drivers GetDriverByRef(string reference)
        {
            if (reference == null || reference == "")
                return null;

            drivers d = db.drivers.Where(x => x.driverRef == reference).FirstOrDefault();
            if (d == null)
                return null;

            return d;
        }

        internal static drivers GetDriverByRef(int? reference)
        {
            if (reference == null)
                return null;

            drivers d = db.drivers.Where(x => x.driverId == reference).FirstOrDefault();
            if (d == null)
                return null;

            return d;
        }
    }
}