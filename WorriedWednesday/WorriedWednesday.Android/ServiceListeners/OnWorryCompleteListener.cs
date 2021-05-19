using Android.Gms.Tasks;
using Firebase.Firestore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorriedWednesday.Droid.Extensions;
using WorriedWednesday.Models;

namespace WorriedWednesday.Droid.ServiceListeners
{
  public class OnWorryCompleteListener : Java.Lang.Object, IOnCompleteListener
  {
    private TaskCompletionSource<List<Worry>> _tcs;

    public OnWorryCompleteListener(TaskCompletionSource<List<Worry>> tcs)
    {
      _tcs = tcs;
    }

    public void OnComplete(Android.Gms.Tasks.Task task)
    {

      if (task.IsSuccessful)
      {
        // process document
        var result = task.Result;
        if (result is DocumentSnapshot doc)
        {
          List<Worry> worries = new List<Worry>();
          var tempWorries = JavaLangExtensions.ToDictionary(new Dictionary<string, Java.Lang.Object>() { { "Worries", doc.Get("Worries") } }).Values;
          foreach (object obj in tempWorries)
          {
            worries.Add((Worry)obj);
          }
          _tcs.TrySetResult(worries);
          return;
        }
      }
      _tcs.TrySetResult(default(List<Worry>));
    }
  }
}