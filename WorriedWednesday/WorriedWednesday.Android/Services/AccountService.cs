using System;
using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using WorriedWednesday.Droid.ServiceListeners;
using WorriedWednesday.Droid.Services;
using WorriedWednesday.Models;
using WorriedWednesday.Services.Account;
using Xamarin.Forms;
using Xamarin.Essentials;

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
    public Task<AuthenticatedUser> GetUserAsync()
    {
      var tcs = new TaskCompletionSource<AuthenticatedUser>();
      Console.WriteLine("              @#$%$#@#$%^(*()(*&*()*&            yes it's getting the currentuserid                (*&*(*&(*&*&*(*&*(*&REREWR%^");

      //firebasefirestore.instance keeps breaking :(

      FirebaseFirestore.Instance
        .Collection("users")
        .Document(FirebaseAuth.Instance.CurrentUser.Uid)
        .Get()
        .AddOnCompleteListener(new OnCompleteListener(tcs));
      return tcs.Task;
    }


  }
}