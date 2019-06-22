using F1_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F1_mvc.Models.GUI;

namespace F1_mvc.Controllers
{
    public class ConstructorsController : Controller
    {
        internal static readonly ModelF1 db = new ModelF1();
        
        // GET: Constructors
        public ActionResult Index()
        {
            ViewBag.Title = "Constructors";
            return View();
        }
        
        public ActionResult Details(string id)
        {
            var cons = Queries.GetConstructorsById(id, db);
            if (cons == null)
                throw new HttpException(404, "The constructor " + id + " requested is not in the database.");

            ConstructorModel model = new ConstructorModel()
            {
                Constructor = cons
            };
            
            ViewBag.Title = cons.name;

            return View(model);
        }

        public PartialViewResult GridConstructors()
        {
            return PartialView("_GridConstructors", db.constructors.OrderBy(x => x.name).ToList());
        }
        

    }
}