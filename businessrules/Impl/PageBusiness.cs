using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules.Impl
{
  public class PageBusiness: ServiceRepository.Impl.Abstracts.EntityBaseRepository<DTO.Entities.Page>,
    Interfaces.IEntityBase<DTO.Entities.Page>
  {
    public void Create(DTO.Entities.Page page)
    {
      base.Insert(page);
    }
  }
}
