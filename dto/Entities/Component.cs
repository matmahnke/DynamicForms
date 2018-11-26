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
  [TableName("Components")]
  public class Component : BaseEntity
  {
    public Component()
    {
    }

    public Component(int pageID, int customEntityID, int type)
    {
      PageID = pageID;
      CustomEntityID = customEntityID;
      Type = type;
    }

    [NotNull]
    [PropertyType(SQLDataTypes.INT)]
    [ForeignKey("Pages", "ID")]
    public int PageID { get; set; }

    [NotNull]
    [PropertyType(SQLDataTypes.INT)]
    [ForeignKey("CustomEntities", "ID")]
    public int CustomEntityID { get; set; }

    //Reference form or grid by [flags] enum
    [NotNull]
    [PropertyType(SQLDataTypes.INT)]
    public int Type { get; set; }
  }
}
