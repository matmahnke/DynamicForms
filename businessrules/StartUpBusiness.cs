using DTO.DatabaseDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules
{
  public class StartUpBusiness
  {
    public StartUpBusiness()
    {
      new SetDB(true);
    }
  }
}
