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
  [TableName("Entities")]
  public class Entity: BaseEntity
  {
    public Entity()
    {
    }

    public Entity(string name, string dbName)
    {
      Name = name;
      DbName = dbName;
    }

    [NotNull]
    [PropertyType(SQLDataTypes.NVARCHAR_MAX)]
    public string Name { get; set; }

    [NotNull]
    [PropertyType(SQLDataTypes.NVARCHAR_MAX)]
    public string DbName { get; set; }
  }
}
