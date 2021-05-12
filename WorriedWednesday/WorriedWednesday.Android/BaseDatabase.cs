using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorriedWednesday.Services;

namespace WorriedWednesday.Droid
{
  public abstract class BaseDatabase<T> : IDatabase<T> where T : IIdentifiable
  {
    protected abstract string DocumentPath { get;  }
    public BaseDatabase()
    {
    }
    public virtual Task<T> Get(string id)
    {
      var tcs = new TaskCompletionSource<T>();
      FirebaseFirestore.Instance
        .Collection(DocumentPath)
        .Document(id)
        .Get()
        .AddOnCompleteListener(new OnDocumentCompleteListener<T>(tcs));
        return tcs.Task;
        }
    public Task<IList<T>> GetAll()
    {
      throw new NotImplementedException();
    }
    public virtual Task<bool> Save(T items)
    {

      throw new NotImplementedException();
    }
    public virtual Task<bool> Delete(T item)
    {

      throw new NotImplementedException();
    }
  }
}