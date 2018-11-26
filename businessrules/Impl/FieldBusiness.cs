using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules.Impl
{
  public class FieldBusiness: ServiceRepository.Impl.Abstracts.EntityBaseRepository<DTO.Entities.Field>, Interfaces.IEntityBase<DTO.Entities.Field>
  {
    public void Create(DTO.Entities.Field field)
    {
      base.Insert(field);
    }
  }
}
