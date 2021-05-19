using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorriedWednesday.Models;

namespace WorriedWednesday.Services.Account
{
  public class MockAccountService : IAccountService
  {
    List<AuthenticatedUser> users = new List<AuthenticatedUser>();
    AuthenticatedUser user;
    int _index;


    // any non-blank entry will succesfully log in, but program will remember the entered email as the current logged in user's Id
    public Task<bool> LoginAsync(string email, string password)
    {
      if(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
      {
        return Task.FromResult(false);
      }

      int index = users.FindIndex(user => user.Id == email);
      if (index != -1)
      {
        user = users[index];
        _index = index;
      }
      else
      {
        _index = users.Count;
        user = new AuthenticatedUser();
        user.Id = email;
        user.Worries = new List<Worry>();
        users.Add(user);
      }
      return Task.Delay(500).ContinueWith((Task) => true);
    }

    public Task<bool> RegisterAsync(string username, string email, string password)
    {
      if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
      {
        return Task.FromResult(false);
      }
      return Task.Delay(500).ContinueWith((Task) => true);
    }

    public Task<bool> PasswordResetAsync(string email)
    {
      return Task.Delay(500).ContinueWith((Task) => true);
    }

    public Task<AuthenticatedUser> GetUserAsync()
    {
      return Task.FromResult(user);
    }

    public Task<bool> AddWorryAsync(Worry worry)
    {
      users[_index].Worries.Add(worry);
      user = users[_index];
      return Task.FromResult(true);
    }

    public Task<bool> AddReplyAsync(Worry worry, Reply reply)
    {
      int userIndex = users.FindIndex(match => match.Id == worry.AuthorId);
      int index = users[userIndex].Worries.FindIndex(matchWorry => matchWorry.Equals(worry)); 

      if (index == -1)
      {
        return Task.FromResult(false);
      }

      users[userIndex].Worries[index].Replies.Add(reply);
      return Task.FromResult(true);
    }

  }
}
