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
  [TableName("CustomEntities")]
  public class CustomEntity : BaseEntity
  {
    public CustomEntity()
    {
    }

    public CustomEntity(int entityID, string description)
    {
      EntityID = entityID;
      Description = description;
    }

    [NotNull]
    [PropertyType(SQLDataTypes.INT)]
    [ForeignKey("Entities", "ID")]
    public int EntityID { get; set; }

    [NotNull]
    [PropertyType(SQLDataTypes.NVARCHAR_MAX)]
    public string Description { get; set; }
  }
}
