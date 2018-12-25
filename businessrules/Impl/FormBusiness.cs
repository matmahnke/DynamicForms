using DataAccessLayer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Impl.Extensions;
using DataAccessLayer.Infrastructure.Extensions;
using DTO.Entities;

namespace BusinessRules.Impl
{
    public class FormBusiness
    {
        public void Insert(DTO.Entities.Entity entity, List<Tuple<string, string>> fields)
        {
            string query = "";
            query += $"INSERT INTO {entity.DbName} ({GenerateParameters(fields, false)}) VALUES({GenerateParameters(fields, true)})";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            foreach (var field in fields)
            {
                command.Parameters.AddWithValue(field.Item1, field.Item2);
            }
            command.Parameters.AddWithValue("@Ativo", true);

            new DBExecuter().Execute(command);
        }

        public IList<IList<Tuple<CustomField, string>>> Select(DTO.Entities.Entity entity, List<CustomField> customFields)
        {
            string query = "";
            query += $"SELECT * FROM {entity.DbName}";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            var table = new DBExecuter().GetData(command);
            var tupleCollection = table.ToTupleCollection();
            var lista = new List<IList<Tuple<CustomField, string>>>();

            foreach (var tuple in tupleCollection)
            {
                tuple.Remove(tuple.FirstOrDefault(c => c.Item1 == "ID"));
                tuple.Remove(tuple.FirstOrDefault(c => c.Item1 == "Ativo"));
            }

            var fields = new FieldBusiness().GetAll().Where(c => customFields.Select(d => d.FieldID.ToString()).ToList().Contains(c.ID.ToString()));

            if (tupleCollection.Count == 0)
            {
                var tuples = new List<Tuple<CustomField, string>>();

                foreach (var customField in customFields)
                {
                    tuples.Add(new Tuple<CustomField, string>(customField, null));
                }
                lista.Add(tuples);
            }

            foreach (var tupleList in tupleCollection)
            {
                var tuples = new List<Tuple<CustomField, string>>();
                foreach (var tuple in tupleList)
                {
                    var field = fields.FirstOrDefault(c => c.Name == tuple.Item1);
                    var customField = customFields.FirstOrDefault(c => c.FieldID == field.ID);
                    tuples.Add(new Tuple<CustomField, string>(customField, tuple.Item2));
                }
                lista.Add(tuples);
            }
            return lista;
        }

        private string GenerateParameters(List<Tuple<string, string>> fields, bool isParam)
        {
            string query = "";
            foreach (var field in fields)
            {
                if (isParam)
                {
                    query += ("@" + field.Item1 + ",");
                }
                else
                {
                    query += ("[" + field.Item1 + "]" + ",");
                }
            }

            if (isParam)
            {
                query += ("@Ativo");
            }
            else
            {
                query += ("[Ativo]");
            }
            return query;
        }
    }
}
