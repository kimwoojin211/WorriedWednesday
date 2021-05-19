using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.Gms.Tasks;
using Firebase.Firestore;
using WorriedWednesday.Droid.Extensions;
using WorriedWednesday.Models;

namespace WorriedWednesday.Droid.ServiceListeners
{
  public class OnCompleteListener : Java.Lang.Object, IOnCompleteListener
  {
    private TaskCompletionSource<AuthenticatedUser> _tcs;

    public OnCompleteListener(TaskCompletionSource<AuthenticatedUser> tcs)
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
          var user = new AuthenticatedUser();
          user.Id = doc.Id;
          var tempWorries = JavaLangExtensions.ToDictionary(new Dictionary<string, Java.Lang.Object>() { { "Worries", doc.Get("Worries") } }).Values;
          foreach (object obj in tempWorries)
          {
            user.Worries.Add((Worry)obj);
          }
          _tcs.TrySetResult(user);
          return;
        }
      }
      _tcs.TrySetResult(default(AuthenticatedUser));
    }
  }
}