using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceRepository.Interfaces
{
  public interface IEntityBaseRepository<T>
  {
    void Insert(T item);
    void Update(T item);
    void Delete(T item);
    T GetByID(int id);
    IList<T> GetAll();
    IList<T> GetAllIn(IList<string> Ids);
  }
}
