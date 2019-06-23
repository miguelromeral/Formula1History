using F1_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F1_mvc.Models.GUI;

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
            GrandPrixModel gp = new GrandPrixModel(id, ref db);
            if (gp.Race == null)
                throw new HttpException(404, "The race " + id + " requested is not in the database.");
            
            ViewBag.Title = gp.Race.year +" "+ gp.Race.name;
            

            return View(gp);
        }
        
        public PartialViewResult RaceResults(GrandPrixModel gp)
        {
            return PartialView("_RaceResults", gp);
        }

        public PartialViewResult QualyResults(GrandPrixModel gp)
        {
            return PartialView("_QualyResults", gp);
        }



        
        [ActionName("GridRace")]
        public PartialViewResult GridRace()
        {
            return PartialView("_GridRace", db.races.OrderBy(x => x.date).ToList());
        }

        [ActionName("GridRaceDriver")]
        public PartialViewResult GridRace(string id)
        {
            var dri = DriversController.GetDriverByRef(id);
            if (dri == null)
                throw new HttpException(404, "The driver " + id + " requested is not in the database.");

            var q = from rac in db.races
                    join res in db.results
                    on rac.raceId equals res.raceId
                    where res.driverId == dri.driverId
                    orderby rac.year ascending, rac.round ascending
                    select rac;

            return PartialView("_GridRace", q.ToList());
        }

        [ActionName("GridPolesDriver")]
        public PartialViewResult GridPoles(string id)
        {
            var dri = DriversController.GetDriverByRef(id);
            if (dri == null)
                throw new HttpException(404, "The driver " + id + " requested is not in the database.");
            
            var q = from rac in db.races
                    join res in db.results
                    on rac.raceId equals res.raceId
                    where res.driverId == dri.driverId && res.grid == 1
                    orderby rac.year ascending, rac.round ascending
                    select rac;
            
            return PartialView("_GridRace", q.ToList());
        }

        [ActionName("GridWinsDriver")]
        public PartialViewResult GridWins(string id)
        {
            var dri = DriversController.GetDriverByRef(id);
            if (dri == null)
                throw new HttpException(404, "The driver " + id + " requested is not in the database.");
            
            var q = from rac in db.races
                    join res in db.results
                    on rac.raceId equals res.raceId
                    where res.driverId == dri.driverId && res.position == 1
                    orderby rac.year ascending, rac.round ascending
                    select rac;
            
            return PartialView("_GridRace", q.ToList());
        }



        [ActionName("GridRacesTeam")]
        public PartialViewResult GridRacesTeam(string id)
        {
            var con = Queries.GetConstructorsById(id, db);
            if (con == null)
                throw new HttpException(404, "The driver " + id + " requested is not in the database.");

            return PartialView("_GridRace", Queries.GetRacesByConstructorId(con.constructorId, db));
        }

    }
}