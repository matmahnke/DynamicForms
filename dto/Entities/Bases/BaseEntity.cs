using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.DataAnnotations;
using DTO.Enumerators;

namespace DTO.Entities.Bases
{
    public class BaseEntity
    {
        [NotNull]
        [PropertyType("INT           IDENTITY (1, 1)")]
        [NonEditable()]
        public int? ID { get; set; }
        [NotNull]
        [PropertyType(SQLDataTypes.BIT)]
        public bool Ativo { get; set; }
    }
}
