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

    public FormViewModel(CustomEntityViewModel entity, List<CustomFieldViewModel> fields)
    {
      Entity = entity;
      Fields = fields;
    }

    public CustomEntityViewModel Entity { get; set; }

    public List<CustomFieldViewModel> Fields { get; set; }
  }
}
