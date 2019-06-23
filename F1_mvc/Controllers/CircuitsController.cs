using F1_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F1_mvc.Models.GUI;

namespace F1_mvc.Controllers
{
    public class CircuitsController : Controller
    {
        internal static ModelF1 db = new ModelF1();

        // GET: Circuits
        public ActionResult Index()
        {
            return View(db.circuits.OrderBy(x => x.country).ToList());
        }

        public ActionResult Details(string id)
        {
            if (id == null || id == "")
                throw new HttpException(404, "The track "+id+" requested is not in the database.");

            circuits r = db.circuits.Where(x => x.circuitRef == id).FirstOrDefault();
            if(r == null)
                throw new HttpException(404, "The track "+id+" requested is not in the database.");

            ViewBag.Title = r.name;

            CircuitModel model = new CircuitModel()
            {
                Circuit = r,
                TrackRecord = Queries.GetTrackRecordCircuit(r.circuitId, db)
            };
            
            return View(model);
        }


    }
}