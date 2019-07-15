using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F1_mvc.Models;
using F1_mvc.Models.GUI;
using F1_mvc.Classes;

namespace F1_mvc.Controllers
{
    public class SeasonsController : Controller
    {
        internal static ModelF1 db = new ModelF1();

        // GET: Seasons
        public ActionResult Index()
        {
            ViewBag.Title = "Season Calendar";
            return View();
        }
        
        public PartialViewResult GridSeasons()
        {
            SeasonsModel model = new SeasonsModel()
            {
                Seasons = db.seasons.ToList()
            };
        
            return PartialView("_GridSeasons", model);
        }

        public ActionResult Details(int id)
        {
            var s = Queries.GetSeasonByYear(id, db);
            if(s == null)
            {
                throw new HttpException(404, "The season "+id+" requested is not in the database.");
            }

            SingleSeasonModel model = new SingleSeasonModel()
            {
                Season = s,
                DriverChampion = Queries.GetDriverChampionByYear(id, db)
            };

            return View(model);
        }
    }
}