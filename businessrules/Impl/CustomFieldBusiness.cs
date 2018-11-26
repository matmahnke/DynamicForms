using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules.Impl
{
  public class CustomFieldBusiness: ServiceRepository.Impl.Abstracts.EntityBaseRepository<DTO.Entities.CustomField>,
    Interfaces.IEntityBase<DTO.Entities.CustomField>
  {
    public void Create(DTO.Entities.CustomField customField)
    {
      base.Insert(customField);
    }
  }
}
