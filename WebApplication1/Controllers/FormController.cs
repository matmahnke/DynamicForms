using BusinessRules.Impl;
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
                var entityId = properties.FirstOrDefault(c => c.Item1 == "EntityID");
                properties.Remove(entityId);

                properties.RemoveAt(0);

                var entity = new EntityBusiness().GetByID(int.Parse(entityId.Item2));

                new FormBusiness().Insert(entity, properties);

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
