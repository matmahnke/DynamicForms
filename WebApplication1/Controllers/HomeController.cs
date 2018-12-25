using BusinessRules;
using BusinessRules.Impl;
using DTO.DatabaseDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //new StartUpBusiness();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult SetTables()
        {
            var entities = new EntityBusiness().GetAll();
            var fields = new FieldBusiness().GetAll();
            foreach (var entity in entities)
            {
                new SetDB().Create(entity, fields.Where(field => field.EntityID == entity.ID));
            }
            return RedirectToAction("Index");
        }
    }
}
