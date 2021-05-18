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
      System.Console.WriteLine("111111111        11111111111111111111       1111111111");
      if (task.IsSuccessful)
      {
        // process document
        System.Console.WriteLine("2222222222        22222222222222222       2222222222");
        var result = task.Result;
        if (result is DocumentSnapshot doc)
        {
          System.Console.WriteLine("333333333          33333333  333333333              3       3");
          var user = new AuthenticatedUser();
          user.Id = doc.Id;
          //user.Worries = new List<Worry>();
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