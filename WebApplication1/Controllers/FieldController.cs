using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
  public class FieldController : Controller
  {

    // GET: Field/Create
    public ActionResult Create()
    {
      List<Tuple<int, string>> list = new List<Tuple<int, string>>();
      var entities = new BusinessRules.Impl.EntityBusiness().GetAll();
      foreach (var entity in entities)
      {
        list.Add(new Tuple<int, string>(entity.ID.Value, entity.Name));
      }

      var instance = new FieldViewModel() { Entities = list };
      return View(instance);
    }

    // POST: Field/Create
    [HttpPost]
    public ActionResult Create(FieldViewModel collection)
    {
      try
      {
        var entity = BusinessRules.CustomAutoMapper<DTO.Entities.Field, FieldViewModel>.Map(collection);
        new BusinessRules.Impl.FieldBusiness().Create(entity);

        return RedirectToAction("Create");
      }
      catch(Exception ex)
      {
        return View();
      }
    }
  }
}
