﻿using F1_mvc.Models;
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
            if (circuitref == null || circuitref == "")
                return RedirectToAction("Index");
                //throw new HttpException(404, "The track "+circuitref+" requested is not in the database.");

            circuits r = db.circuits.Where(x => x.circuitRef == circuitref).FirstOrDefault();
            if(r == null)
                return RedirectToAction("Index");
            //throw new HttpException(404, "The track "+circuitref+" requested is not in the database.");

            ViewBag.Title = r.name;

            return View(r);
        }


    }
}