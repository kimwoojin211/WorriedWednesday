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

    // to test with active firebase auth database, use
    // email = test@test.com
    // password = 123456
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
   

    public Task<bool> RegisterAsync(string username, string email, string password)
    {
      var tcs = new TaskCompletionSource<bool>();
      FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password)
        .ContinueWith((task) => OnRegisterCompleted(task, tcs));

      return tcs.Task;
    }

    private void OnRegisterCompleted(Task task, TaskCompletionSource<bool> tcs)
    {
      if (task.IsCanceled || task.IsFaulted)
      {
        tcs.SetResult(false);
        return;
      }
      tcs.SetResult(true);
    }

    public Task<bool> PasswordResetAsync(string email)
    {
      var tcs = new TaskCompletionSource<bool>();
      FirebaseAuth.Instance.SendPasswordResetEmailAsync(email)
        .ContinueWith((task) => true);
      return tcs.Task;
    }

    public Task<AuthenticatedUser> GetUserAsync()
    {
      var tcs = new TaskCompletionSource<AuthenticatedUser>();

      //// firebasefirestore.instance keeps breaking :(
      
      FirebaseFirestore.Instance
        .Collection("users")
        .Document(FirebaseAuth.Instance.CurrentUser.Uid)
        .Get()
        .AddOnCompleteListener(new OnCompleteListener(tcs));
      return tcs.Task;
    }

    public Task<bool> AddWorryAsync(Worry worry)
    {
      var tcs = new TaskCompletionSource<bool>();
      return tcs.Task;
    }

    public Task<bool> AddReplyAsync(Worry worry, Reply reply)
    {
      var tcs = new TaskCompletionSource<bool>();
      return tcs.Task;
    }
  }
}