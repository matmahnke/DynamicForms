using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class FormViewModel
    {
        public FormViewModel()
        {
        }

        public FormViewModel(CustomEntityViewModel entity, IList<(CustomFieldViewModel, FieldViewModel)> fields)
        {
            Entity = entity;
            List<Tuple<CustomFieldViewModel, FieldViewModel>> tuples = new List<Tuple<CustomFieldViewModel, FieldViewModel>>();
            foreach (var field in fields)
            {
                tuples.Add(new Tuple<CustomFieldViewModel, FieldViewModel>(field.Item1, field.Item2));
            }
            Fields = tuples;
        }

        public CustomEntityViewModel Entity { get; set; }

        public IList<Tuple<CustomFieldViewModel, FieldViewModel>> Fields { get; set; }
    }
}
