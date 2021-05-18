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

      System.Console.WriteLine("111111111        11111111111111111111       1111111111");
      if (task.IsSuccessful)
      {
        // process document
        System.Console.WriteLine("2222222222        22222222222222222       2222222222");
        var result = task.Result;
        if (result is DocumentSnapshot doc)
        {
          System.Console.WriteLine("333333333          33333333  333333333              3       3");
          List<Worry> worries = new List<Worry>();
          //user.Worries = new List<Worry>();
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