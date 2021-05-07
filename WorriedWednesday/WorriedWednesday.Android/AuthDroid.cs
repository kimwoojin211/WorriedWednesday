using System;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Firebase.Auth;
using Android.Gms.Extensions;

[assembly: Dependency(typeof(WorriedWednesday.Droid.AuthDroid))]
namespace WorriedWednesday.Droid
{
  public class AuthDroid : IAuth
  {
    public bool IsSignIn()
    {
      return true;
    }
    public bool SignOut()
    {
      return true;
    }

    public Task<string> LoginWithEmailAndPassword(string email, string password)
    {
      return null;
    }


    public Task<string> RegisterWithEmailAndPassword(string email, string password)
    {
      return null;

    }
  }
}