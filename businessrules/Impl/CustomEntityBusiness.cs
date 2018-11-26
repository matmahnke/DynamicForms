using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules.Impl
{
  public class CustomEntityBusiness: ServiceRepository.Impl.Abstracts.EntityBaseRepository<DTO.Entities.CustomEntity>,
    Interfaces.IEntityBase<DTO.Entities.CustomEntity>
  {
    public void Create(DTO.Entities.CustomEntity customEntity)
    {
      base.Insert(customEntity);
    }
  }
}
