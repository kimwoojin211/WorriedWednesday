using System.Threading.Tasks;
using Android.Gms.Tasks;
using Firebase.Firestore;
using WorriedWednesday.Models;

namespace WorriedWednesday.Droid
{
  public class OnCompleteListener : Java.Lang.Object, IOnCompleteListener
  {
    private TaskCompletionSource<AuthenticatedUser> _tcs;

    public OnCompleteListener(TaskCompletionSource<AuthenticatedUser> tcs)
    {
      _tcs = tcs;
    }

    public void OnComplete (Android.Gms.Tasks.Task task)
    {
      if (task.IsSuccessful)
      {
        var result = task.Result;
        if(result is DocumentSnapshot doc)
        {
          var user = new AuthenticatedUser();
          user.Id = doc.Id;
          user.Worries = doc.GetString("Worries");
          _tcs.TrySetResult(user);
          return;
        }
      }
      _tcs.TrySetResult(default(AuthenticatedUser));
    }
  }
}