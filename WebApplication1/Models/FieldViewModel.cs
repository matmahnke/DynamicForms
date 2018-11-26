using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
  public class FieldViewModel
  {
    public FieldViewModel()
    {
    }

    public FieldViewModel(string name, string type, int order, bool required, string dbType)
    {
      Name = name;
      Type = type;
      Order = order;
      Required = required;
      DbType = dbType;
    }

    public FieldViewModel(string name, string type, int order, bool required, string dbType, int entityID, IEnumerable<Tuple<int, string>> entities) : this(name, type, order, required, dbType)
    {
      EntityID = entityID;
      Entities = entities;
    }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Type { get; set; }

    [Required]
    public int Order { get; set; }

    [Required]
    public bool Required { get; set; }

    [Required]
    public string DbType { get; set; }

    [Required]
    public int EntityID { get; set; }
    public IEnumerable<Tuple<int, string>> Entities { get; set; }
  }
}
