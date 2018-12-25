using BusinessRules;
using BusinessRules.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GridController : Controller
    {
        // GET: Grid
        public ActionResult Index(int customEntityId)
        {
            ViewBag.customEntityID = customEntityId;
            DTO.Entities.CustomEntity customEntity = new BusinessRules.Impl.CustomEntityBusiness().GetByID(customEntityId);
            var customEntityViewModel = BusinessRules.CustomAutoMapper<CustomEntityViewModel, DTO.Entities.CustomEntity>.Map(customEntity);

            var customFields = new BusinessRules.Impl.CustomFieldBusiness().GetAll().Where(c => c.CustomEntityID == customEntityId);

            var fields = new BusinessRules.Impl.FieldBusiness().GetAll().Where(c => c.EntityID == customEntity.EntityID);

            var customFieldsViewModel = new List<(CustomFieldViewModel, FieldViewModel)>();
            foreach (var customField in customFields)
            {
                customFieldsViewModel.Add(
                        (
                        BusinessRules.CustomAutoMapper<CustomFieldViewModel, DTO.Entities.CustomField>.Map(customField),
                        BusinessRules.CustomAutoMapper<FieldViewModel, DTO.Entities.Field>.Map(fields.FirstOrDefault(c => c.ID == customField.FieldID))
                        )
                    );
            }
            var result = new FormViewModel(customEntityViewModel, customFieldsViewModel);

            var entity = new EntityBusiness().GetByID(customEntity.EntityID);

            var objectColletion = new FormBusiness().Select(entity, customFields.ToList());

            var model = new GridViewModel(CustomAutoMapper<CustomEntityViewModel, DTO.Entities.CustomEntity>.Map(customEntity), objectColletion);

            return View(model);
        }
    }
}