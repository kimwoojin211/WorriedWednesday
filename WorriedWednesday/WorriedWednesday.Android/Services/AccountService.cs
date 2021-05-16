using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorriedWednesday.Services.Account;
using Xamarin.Forms;

[assembly: Dependency(typeof(AccountService))]
namespace WorriedWednesday.Droid.Services
{
  public class AccountService : IAccountService
  {
    public AccountService()
    {
    }
    public Task<bool> LoginAsync(string email, string password)
    {
      var tcs = new TaskCompletionSource<bool>();
      FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password)
        .ContinueWith((task) => OnAuthCompleted(task, tcs));
      return tcs.Task;
    }

    private void OnAuthCompleted(Task task, TaskCompletionSource<bool> tcs)
    {
      if (task.IsCanceled || task.IsFaulted)
      {
        tcs.SetResult(false);
        return;
      }
      tcs.SetResult(true);
    }
  }
}