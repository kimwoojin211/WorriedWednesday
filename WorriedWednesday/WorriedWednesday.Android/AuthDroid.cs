using System;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Firebase.Firestore;
using Firebase.Auth;
using Android.Gms.Extensions;
using WorriedWednesday.Models;


[assembly: Dependency(typeof(WorriedWednesday.Droid.AuthDroid))]
namespace WorriedWednesday.Droid
{
  public class AuthDroid : IAuth
  {
    public bool IsSignIn()
    {
      var user = FirebaseAuth.Instance.CurrentUser;
      return user != null;
    }
    public bool SignOut()
    {
      try
      {
        FirebaseAuth.Instance.SignOut();
        return true;
      }
      catch (Exception e)
      {
        return false;
      }
    }

    public async Task<string> LoginWithEmailAndPassword(string email, string password)
    {
      try
      {
        var user = await FirebaseAuth.Instance.
                    SignInWithEmailAndPasswordAsync(email, password);
        var token = await user.User.GetIdToken(false).AsAsync<GetTokenResult>();

        return token.Token;
      }
      catch (FirebaseAuthInvalidUserException e)
      {
        e.PrintStackTrace();
        return string.Empty;
      }
      catch (FirebaseAuthInvalidCredentialsException e)
      {
        e.PrintStackTrace();
        return string.Empty;
      }
    }


    public async Task<string> RegisterWithEmailAndPassword(string email, string password)
    {
      try
      {
        var user = await FirebaseAuth.Instance.
                    CreateUserWithEmailAndPasswordAsync(email, password);
        var token = await user.User.GetIdToken(false).AsAsync<GetTokenResult>();
        return token.Token;
      }
      catch (FirebaseAuthInvalidUserException e)
      {
        e.PrintStackTrace();
        return string.Empty;
      }
      catch (FirebaseAuthInvalidCredentialsException e)
      {
        e.PrintStackTrace();
        return string.Empty;
      }
    }

    public Task<AuthenticatedUser> GetUserAsync()
    {
      var tcs = new TaskCompletionSource<AuthenticatedUser>();
      FirebaseFirestore.Instance.Collection("users").Document(FirebaseAuth.Instance.CurrentUser.Uid).Get().AddOnCompleteListener(new OnCompleteListener(tcs));
      return tcs.Task;
    }
  }
}