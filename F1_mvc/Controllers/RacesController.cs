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
            return View(db.races.OrderBy(x => x.date).ToList());
        }



        public ActionResult Details(int id)
        {
            var r = GetRaceByID(id);
            if (r == null)
                throw new HttpException(404, "The race " + id + " requested is not in the database.");
            
            ViewBag.Title = r.year +" "+ r.name;

            return View(r);
        }


        public PartialViewResult RaceDetails(int id)
        {
            var r = GetRaceByID(id);
            if (r == null)
                throw new HttpException(404, "The race " + id + " requested is not in the database.");

            Dictionary<string, object> stats = new Dictionary<string, object>();


            //var query = from res in db.results
            //            join dri in db.drivers on res.driverId equals dri.driverId
            //            select dri;


            var q = from res in db.results
                    join dri in db.drivers
                    on res.driverId equals dri.driverId
                    where res.raceId == id
                    select dri;


            var d = q.FirstOrDefault();
            if (d != null)
            {
                stats.Add("Winner", d);
            }



            return PartialView("_RaceDetails", stats);
        }







        private races GetRaceByID(int? id)
        {
            if (id == null)
                return null;

            races d = db.races.Where(x => x.raceId == id).FirstOrDefault();
            if (d == null)
                return null;

            return d;
        }

    }
}