using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
  public class ComponentController : Controller
  {
    // GET: Component/Create
    public ActionResult Create()
    {
      List<Tuple<int, string>> customEntityList = new List<Tuple<int, string>>();
      var entities = new BusinessRules.Impl.CustomEntityBusiness().GetAll();
      foreach (var entity in entities)
      {
        customEntityList.Add(new Tuple<int, string>(entity.ID.Value, entity.Description));
      }

      List<Tuple<int, string>> pageList = new List<Tuple<int, string>>();
      var pages = new BusinessRules.Impl.PageBusiness().GetAll();
      foreach (var entity in pages)
      {
        pageList.Add(new Tuple<int, string>(entity.ID.Value, entity.Name));
      }

      var instance = new Models.ComponentViewModel() { CustomEntities = customEntityList, Pages = pageList };

      return View(instance);
    }

    // POST: Component/Create
    [HttpPost]
    public ActionResult Create(Models.ComponentViewModel collection)
    {
      try
      {
        var entity = BusinessRules.CustomAutoMapper<DTO.Entities.Component, Models.ComponentViewModel>.Map(collection);
        new BusinessRules.Impl.ComponentBusiness().Create(entity);

        return RedirectToAction("Index", "Home");
      }
      catch
      {
        return View();
      }
    }
  }
}
