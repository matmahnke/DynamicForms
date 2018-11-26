using DTO.DataAnnotations;
using DTO.Entities.Bases;
using DTO.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entities
{
  [TableName("Pages")]
  public class Page : BaseEntity
  {
    public Page()
    {
    }

    public Page(string name, string url, string title)
    {
      Name = name;
      Url = url;
      Title = title;
    }

    [NotNull]
    [PropertyType(SQLDataTypes.NVARCHAR_MAX)]
    public string Name { get; set; }

    [NotNull]
    [PropertyType(SQLDataTypes.NVARCHAR_MAX)]
    public string Url { get; set; }

    [NotNull]
    [PropertyType(SQLDataTypes.NVARCHAR_MAX)]
    public string Title { get; set; }
  }
}
