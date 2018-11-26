using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
  public class CustomEntityViewModel
  {
    public CustomEntityViewModel()
    {
    }

    public CustomEntityViewModel(string description)
    {
      Description = description;
    }

    [Required]
    public string Description { get; set; }

    [Required]
    public int EntityID { get; set; }
    public IEnumerable<Tuple<int, string>> Entities { get; set; }
  }
}
