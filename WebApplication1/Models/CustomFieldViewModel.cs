using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
  public class CustomFieldViewModel
  {
    public CustomFieldViewModel()
    {
    }

    public CustomFieldViewModel(string label, string options, string placeholder, string title)
    {
      Label = label;
      Options = options;
      Placeholder = placeholder;
      Title = title;
    }

    public CustomFieldViewModel(string label, string options, string placeholder, string title, int customEntityID, IEnumerable<Tuple<int, string>> customEntities, int fieldID, IEnumerable<Tuple<int, string>> fields, string value) : this(label, options, placeholder, title)
    {
      CustomEntityID = customEntityID;
      CustomEntities = customEntities;
      FieldID = fieldID;
      Fields = fields;
      Value = value;
    }

    [Required]
    public string Label { get; set; }

    [Required]
    public string Options { get; set; }

    [Required]
    public string Placeholder { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public int CustomEntityID { get; set; }
    public IEnumerable<Tuple<int, string>> CustomEntities { get; set; }

    [Required]
    public int FieldID { get; set; }
    public IEnumerable<Tuple<int, string>> Fields { get; set; }

    public string Value { get; set; }
  }
}
