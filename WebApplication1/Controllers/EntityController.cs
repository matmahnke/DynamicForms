using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
  public class EntityController : Controller
  {
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(EntityViewModel entityViewModel)
    {
      try
      {
        var entity = BusinessRules.CustomAutoMapper<DTO.Entities.Entity, EntityViewModel>.Map(entityViewModel);
        new BusinessRules.Impl.EntityBusiness().Create(entity);

        return RedirectToAction("Create", "Field");
      }
      catch (Exception ex)
      {
        return View();
      }
    }
  }
}
