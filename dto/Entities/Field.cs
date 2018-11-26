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
  [TableName("Fields")]
  public class Field : BaseEntity
  {
    public Field()
    {
    }

    public Field(int entityID, string name, string type, int order, bool required, string dbType)
    {
      EntityID = entityID;
      Name = name;
      Type = type;
      Order = order;
      Required = required;
      DbType = dbType;
    }

    [NotNull]
    [PropertyType(SQLDataTypes.INT)]
    [ForeignKey("Entities", "ID")]
    public int EntityID { get; set; }

    [NotNull]
    [PropertyType(SQLDataTypes.NVARCHAR_MAX)]
    public string Name { get; set; }

    [NotNull]
    [PropertyType(SQLDataTypes.NVARCHAR_MAX)]
    public string Type { get; set; }

    [NotNull]
    [PropertyType(SQLDataTypes.INT)]
    public int Order { get; set; }

    [NotNull]
    [PropertyType(SQLDataTypes.BIT)]
    public bool Required { get; set; }

    [NotNull]
    [PropertyType(SQLDataTypes.NVARCHAR_MAX)]
    public string DbType { get; set; }
  }
}
