using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Entities;

namespace BusinessRules.Impl
{
  public class EntityBusiness : ServiceRepository.Impl.Abstracts.EntityBaseRepository<DTO.Entities.Entity>, Interfaces.IEntityBase<DTO.Entities.Entity>
  {
    public void Create(Entity entity)
    {
      base.Insert(entity);
    }
  }
}
