using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
  public class CustomEntityController : Controller
  {
    public ActionResult Create()
    {
      List<Tuple<int, string>> list = new List<Tuple<int, string>>();
      var entities = new BusinessRules.Impl.EntityBusiness().GetAll();
      foreach (var entity in entities)
      {
        list.Add(new Tuple<int, string>(entity.ID.Value, entity.Name));
      }

      var instance = new CustomEntityViewModel() { Entities = list };
      return View(instance);
    }

    [HttpPost]
    public ActionResult Create(CustomEntityViewModel collection)
    {
      try
      {
        var entity = BusinessRules.CustomAutoMapper<DTO.Entities.CustomEntity, CustomEntityViewModel>.Map(collection);
        new BusinessRules.Impl.CustomEntityBusiness().Create(entity);

        return RedirectToAction("Create", "CustomField");
      }
      catch
      {
        return View();
      }
    }
  }
}
