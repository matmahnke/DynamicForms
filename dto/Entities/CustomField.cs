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
  [TableName("CustomFields")]
  public class CustomField : BaseEntity
  {
    public CustomField()
    {
    }

    public CustomField(int fieldID, int customEntityID, string label, string options, string placeholder, string title)
    {
      FieldID = fieldID;
      CustomEntityID = customEntityID;
      Label = label;
      Options = options;
      Placeholder = placeholder;
      Title = title;
    }

    [NotNull]
    [PropertyType(SQLDataTypes.INT)]
    [ForeignKey("Fields", "ID")]
    public int FieldID { get; set; }

    [NotNull]
    [PropertyType(SQLDataTypes.INT)]
    [ForeignKey("CustomEntities", "ID")]
    public int CustomEntityID { get; set; }

    [NotNull]
    [PropertyType(SQLDataTypes.NVARCHAR_MAX)]
    public string Label { get; set; }

    [NotNull]
    [PropertyType(SQLDataTypes.NVARCHAR_MAX)]
    public string Options { get; set; }

    [NotNull]
    [PropertyType(SQLDataTypes.NVARCHAR_MAX)]
    public string Placeholder { get; set; }

    [NotNull]
    [PropertyType(SQLDataTypes.NVARCHAR_MAX)]
    public string Title { get; set; }
  }
}
