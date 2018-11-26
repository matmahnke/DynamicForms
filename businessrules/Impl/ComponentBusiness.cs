using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules.Impl
{
  public class ComponentBusiness:
    ServiceRepository.Impl.Abstracts.EntityBaseRepository<DTO.Entities.Component>,
    Interfaces.IEntityBase<DTO.Entities.Component>
  {
    public void Create(DTO.Entities.Component component)
    {
      base.Insert(component);
    }
  }
}
