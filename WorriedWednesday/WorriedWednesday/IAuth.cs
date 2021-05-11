using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorriedWednesday.Models;

namespace WorriedWednesday
{
  public interface IAuth
  {
    Task<string> LoginWithEmailAndPassword(string email, string password);

    Task<string> RegisterWithEmailAndPassword(string email, string password);
    bool SignOut();
    bool IsSignIn();

    Task<AuthenticatedUser> GetUserAsync();
  }
}
