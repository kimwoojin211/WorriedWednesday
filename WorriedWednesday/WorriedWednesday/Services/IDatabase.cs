using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorriedWednesday.Services
{
  public interface IIdentifiable
  {
    string Id { get; set; }
  }
  public interface IDatabase<T> where T : IIdentifiable
  {
    Task<T> Get(string id);
    Task<IList<T>> GetAll();
    Task<bool> Save(T item);
    Task<bool> Delete(T item);
  }
}
