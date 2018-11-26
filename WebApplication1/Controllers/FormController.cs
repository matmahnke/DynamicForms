using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
  public class FormController : Controller
  {
    // GET: Form/Create
    public ActionResult Create(int customEntityId)
    {
      DTO.Entities.CustomEntity customEntity = new BusinessRules.Impl.CustomEntityBusiness().GetByID(customEntityId);
      var customEntityViewModel = BusinessRules.CustomAutoMapper<CustomEntityViewModel, DTO.Entities.CustomEntity>.Map(customEntity);

      var customFields = new BusinessRules.Impl.CustomFieldBusiness().GetAll().Where(c => c.CustomEntityID == customEntityId);
      var customFieldsViewModel = new List<CustomFieldViewModel>();
      foreach (var customField in customFields)
      {
        customFieldsViewModel.Add(BusinessRules.CustomAutoMapper<CustomFieldViewModel, DTO.Entities.CustomField>.Map(customField));
      }
      var result = new FormViewModel(customEntityViewModel, customFieldsViewModel);
      return View(result);
    }

    // POST: Form/Create
    [HttpPost]
    public ActionResult Create(FormCollection collection)
    {
      try
      {
        List<Tuple<string, string>> properties = new List<Tuple<string, string>>();
        foreach (var item in collection.AllKeys)
        {
          properties.Add(new Tuple<string, string>(item, collection[item]));
        }
        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }
  }
}
