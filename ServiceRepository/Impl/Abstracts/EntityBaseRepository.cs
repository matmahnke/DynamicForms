using DataAccessLayer.Impl;
using DTO.Entities.Bases;
using ServiceRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceRepository.Impl.Abstracts
{
  public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : BaseEntity
  {
    private static string GetTableName<T>()
    {
      return ((DTO.DataAnnotations.TableName)typeof(T).GetCustomAttributes(typeof(DTO.DataAnnotations.TableName), false)[0]).Text;
    }
    public void Delete(T item)
    {
      throw new NotImplementedException();
    }

    public IList<T> GetAll()
    {
      List<T> result = new List<T>();
      using (DAL<T> dal = new DAL<T>())
      {
        result.AddRange(dal.Query($"SELECT * FROM {GetTableName<T>()}"));
      }
      return result;
    }

    public IList<T> GetAllIn(IList<string> Ids)
    {
      string ids = "";

      foreach (var id in Ids)
      {
        ids += id + ",";
      }

      ids.Remove(ids.Length - 1);

      List<T> result = new List<T>();
      using (DAL<T> dal = new DAL<T>())
      {
        result.AddRange(dal.Query($"SELECT * FROM {GetTableName<T>()} WHERE ID IN({ids})"));
      }
      return result;
    }

    public T GetByID(int id)
    {
      T result;
      using (DAL<T> dal = new DAL<T>())
      {
        result = dal.Query($"SELECT * FROM {GetTableName<T>()} WHERE ID = {id}")[0];
      }
      return result;
    }

    public void Insert(T item)
    {
      item.Ativo = true;
      using (DAL<T> dal = new DAL<T>())
      {
        dal.Insert(item);
      }
    }

    public void Update(T item)
    {
      using (DAL<T> dal = new DAL<T>())
      {
        dal.Update(item);
      }
    }
  }
}
