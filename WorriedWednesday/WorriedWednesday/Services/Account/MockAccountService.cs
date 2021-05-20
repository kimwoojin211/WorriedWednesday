using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorriedWednesday.Models;

namespace WorriedWednesday.Services.Account
{
  public class MockAccountService : IAccountService
  {
    List<TestUser> userDB = new List<TestUser>();

    AuthenticatedUser authUser;
    int _index;


    // any non-blank entry will succesfully log in, but program will remember the entered email as the current logged in user's Id
    public Task<bool> LoginAsync(string email, string password)
    {
      int index = userDB.FindIndex(user => user.Email == email && user.Password == password);
      if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || index == -1)
      {
        return Task.FromResult(false);
      }

      authUser = TestToAuth(userDB[index]);
      _index = index;
      return Task.Delay(500).ContinueWith((Task) => true);
    }

    public Task<bool> RegisterAsync(string name, string email, string password)
    {

      if(userDB.FindIndex(user => user.Email == email) != -1)
      {
        return Task.FromResult(false);
      }
      TestUser newUser = new TestUser(userDB.Count.ToString(), name, email, password);
      userDB.Add(newUser);
      return Task.Delay(500).ContinueWith((Task) => true);
    }

    public Task<bool> PasswordResetAsync(string email)
    {
      return Task.Delay(500).ContinueWith((Task) => true);
    }

    public Task<AuthenticatedUser> GetUserAsync()
    {
      return Task.FromResult(authUser);
    }

    public Task<bool> AddWorryAsync(Worry worry)
    {
      //user.Worries.Insert(0,worry);
      userDB[_index].Worries.Add(worry);
      authUser = TestToAuth(userDB[_index]);
      return Task.FromResult(true);
    }

    public Task<bool> AddReplyAsync(Worry worry, Reply reply)
    {
      int userIndex = userDB.FindIndex(match => match.Id == worry.AuthorId);
      int index = userDB[userIndex].Worries.FindIndex(matchWorry => matchWorry.Equals(worry)); 

      if (index == -1)
      {
        return Task.FromResult(false);
      }

      userDB[userIndex].Worries[index].Replies.Add(reply);
      return Task.FromResult(true);
    }
    //public Task<bool> LogWorryAsync(Worry worry)
    //{
    //  Worries.Insert(0, worry);
    //  return Task.FromResult(true);
    //}

    private AuthenticatedUser TestToAuth(TestUser TestUser)
    {
      AuthenticatedUser authUser = new AuthenticatedUser();
      authUser.Id = TestUser.Id;
      authUser.Name = TestUser.Name;
      authUser.Worries = TestUser.Worries;
      return authUser;
    }
  }
}
