using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using WorriedWednesday.Services;

namespace WorriedWednesday.iOS.Services
{
  public abstract class BaseRepository<T> : IRepository<T> where T : IIdentifiable
  {
    public abstract string DocumentPath { get; }
    public virtual Task<T> Get(string id)
    {
      var tcs = new TaskCompletionSource<T>();
      Firebase.CloudFirestore.Firestore.SharedInstance
        .GetCollection(DocumentPath)
        .GetDocument(id)
        .GetDocument((snapshot, error) =>
        {
          if (error != null)
          {
            tcs.TrySetResult(default);
            return;
          }
        });
      return tcs.Task;
    }

    public Task<IList<T>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<string> Save(T item)
    {
      throw new NotImplementedException();
    }

    public Task<bool> Delete(T item)
    {
      throw new NotImplementedException();
    }
  }
}