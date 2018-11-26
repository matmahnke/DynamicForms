using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
  public class EntityViewModel
  {
    public EntityViewModel()
    {
    }

    public EntityViewModel(string name, string dbName)
    {
      Name = name;
      DbName = dbName;
    }

    [Required]
    public string Name { get; set; }

    [Required]
    public string DbName { get; set; }
  }
}
