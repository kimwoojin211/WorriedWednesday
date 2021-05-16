using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorriedWednesday.Services.Account
{
  public class AccountService :IAccountService
  {
    public Task<bool> LoginAsync(string email, string password)
    {
      if(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
      {
        return Task.FromResult(false);
      }
      return Task.Delay(500).ContinueWith((Task) => true);
    }
  }
}
