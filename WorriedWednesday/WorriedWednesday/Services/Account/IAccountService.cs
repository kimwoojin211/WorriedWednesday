using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorriedWednesday.Models;

namespace WorriedWednesday.Services.Account
{
  public interface IAccountService
  {    
    Task<bool> LoginAsync(string email, string password);
    Task<bool> RegisterAsync(string name, string email, string password);
    Task<bool> PasswordResetAsync(string email);
    Task<AuthenticatedUser> GetUserAsync();
    Task<bool> AddWorryAsync(Worry worry);
    Task<bool> AddReplyAsync(Worry worry, Reply reply);
  }
}
