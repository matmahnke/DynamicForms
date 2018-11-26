using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
  public class PageController : Controller
  {
    // GET: Page/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Page/Create
    [HttpPost]
    public ActionResult Create(PageViewModel collection)
    {
      try
      {
        var entity = BusinessRules.CustomAutoMapper<DTO.Entities.Page, PageViewModel>.Map(collection);
        new BusinessRules.Impl.PageBusiness().Create(entity);

        return RedirectToAction("Create", "Component");
      }
      catch
      {
        return View();
      }
    }
  }
}
