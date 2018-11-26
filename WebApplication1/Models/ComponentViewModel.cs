using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
  public class ComponentViewModel
  {
    public ComponentViewModel()
    {
    }

    public ComponentViewModel(int type)
    {
      Type = type;
    }

    [Required]
    public int Type { get; set; }

    [Required]
    public int CustomEntityID { get; set; }
    public IEnumerable<Tuple<int, string>> CustomEntities { get; set; }

    [Required]
    public int PageID { get; set; }
    public IEnumerable<Tuple<int, string>> Pages { get; set; }
  }
}
