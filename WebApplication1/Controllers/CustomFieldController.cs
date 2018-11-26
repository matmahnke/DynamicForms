using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
  public class CustomFieldController : Controller
  {
    // GET: CustomField/Create
    public ActionResult Create()
    {
      var customEntityList = new List<Tuple<int, string>>();
      var fieldList = new List<Tuple<int, string>>();
      {
        var entities = new BusinessRules.Impl.CustomEntityBusiness().GetAll();
        foreach (var entity in entities)
        {
          customEntityList.Add(new Tuple<int, string>(entity.ID.Value, entity.Description));
        }
      }
      {
        var fields = new BusinessRules.Impl.FieldBusiness().GetAll();
        foreach (var entity in fields)
        {
          fieldList.Add(new Tuple<int, string>(entity.ID.Value, entity.Name));
        }
      }

      var instance = new Models.CustomFieldViewModel() { CustomEntities = customEntityList, Fields = fieldList, CustomEntityID = customEntityList.FirstOrDefault().Item1 };

      return View(instance);
    }

    // POST: CustomField/Create
    [HttpPost]
    public ActionResult Create(CustomFieldViewModel collection)
    {
      try
      {
        var entity = BusinessRules.CustomAutoMapper<DTO.Entities.CustomField, CustomFieldViewModel>.Map(collection);
        new BusinessRules.Impl.CustomFieldBusiness().Create(entity);
        return RedirectToAction("Create");
      }
      catch
      {
        return View();
      }
    }
  }
}
