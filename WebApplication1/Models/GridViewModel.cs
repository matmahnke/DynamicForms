using BusinessRules;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class GridViewModel
    {
        public GridViewModel()
        {
        }

        public GridViewModel(CustomEntityViewModel entity, IList<IList<Tuple<CustomField, string>>> fields)
        {
            var lista = new List<IList<Tuple<CustomFieldViewModel, string>>>();
            if (fields != null)
                foreach (var field in fields)
                {
                    var l2 = new List<Tuple<CustomFieldViewModel, string>>();
                    foreach (var item in field)
                    {
                        l2.Add(new Tuple<CustomFieldViewModel, string>(CustomAutoMapper<CustomFieldViewModel, CustomField>.Map(item.Item1), item.Item2));
                    }
                    lista.Add(l2);
                }
            Entity = entity;
            Fields = lista;
        }

        public CustomEntityViewModel Entity { get; set; }

        public IList<IList<Tuple<CustomFieldViewModel, string>>> Fields { get; set; }
    }
}
