﻿using F1_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F1_mvc.Models.GUI;

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
            
            DriverModel model = new DriverModel()
            {
                Driver = r,
                Seasons = Classes.Queries.GetSeasonsCount(db, r.driverId),
                Races = db.results.Where(x => x.driverId == r.driverId).Count(),
                Poles = db.results.Where(x => x.driverId == r.driverId && x.grid == 1).Count(),
                FastestLaps = Classes.Queries.GetFastestLapCount(db, r.driverId),
                Wins = db.results.Where(x => x.driverId == r.driverId && x.position == 1).Count(),
                Championships = Classes.Queries.GetChampionshipCount(db, r.driverId),
            };

            ViewBag.Title = model.GetDriverFullname();

            return View(model);
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