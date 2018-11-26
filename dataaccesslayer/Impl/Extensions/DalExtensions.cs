using DataAccessLayer.Infrastructure;
using DataAccessLayer.Infrastructure.Extensions;
using DTO;
using DTO.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Impl.Extensions
{
    public static class DalExtensions
    {
        public static int Delete(this BaseEntity item)
        {
            return new DBExecuter().Execute(SqlGenerator.BuildDeleteCommand(item));
        }

        public static int Insert(this BaseEntity item)
        {
            return new DBExecuter().Execute(SqlGenerator.BuildInsertCommand(item));
        }

        public static List<object> Select(this BaseEntity item)
        {
            DataTable table = new DBExecuter().GetData(SqlGenerator.BuildSelectCommand(item));
            if (table.Rows.Count == 0)
                return null;
            return table.ToObjectCollection(item);
        }

        public static int Update(this BaseEntity item)
        {
            return new DBExecuter().Execute(SqlGenerator.BuildUpdateCommand(item));
        }
    }
}
