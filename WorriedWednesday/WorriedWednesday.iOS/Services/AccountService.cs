﻿using Foundation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Core;
using WorriedWednesday.Models;
using Firebase.Auth;
using WorriedWednesday.Services.Account;
using Xamarin.Forms;

namespace WorriedWednesday.iOS.Services
{
  public class AccountService : IAccountService
  {
    public AccountService()
    {

    }


    public Task<bool> LoginAsync(string email,string password)
    {
      var tcs = new TaskCompletionSource<bool>();
      Auth.DefaultInstance.SignInWithPasswordAsync(email, password)
        .ContinueWith((Task) => OnAuthCompleted(Task, tcs));
      return tcs.Task;
    }

    private void OnAuthCompleted(Task task, TaskCompletionSource<bool> tcs)
    {
      if (task.IsCanceled || task.IsFaulted)
      {
        //something went wrong
        tcs.SetResult(false);
        return;
      }
      //user is logged in
      tcs.SetResult(true);
    }

    public Task<bool> RegisterAsync(string username, string email, string password)
    {
      throw new NotImplementedException();
    }
    public Task<bool> PasswordResetAsync(string email)
    {
      throw new NotImplementedException();
    }

    public Task<AuthenticatedUser> GetUserAsync()
    {
      var tcs = new TaskCompletionSource<AuthenticatedUser>();

      //// firebasefirestore.sharedinstance keeps breaking :(

      Firebase.CloudFirestore.Firestore.SharedInstance
        .GetCollection("users")
        .GetDocument(Auth.DefaultInstance.CurrentUser.Uid)
        .GetDocument((snapshot, error) =>
        {
          if (error != null)
          {
            tcs.TrySetResult(default(AuthenticatedUser));
            return;
          }
          tcs.TrySetResult(new AuthenticatedUser
          {
            Id = snapshot.Id
          });
        });
      return tcs.Task;

    }

    public Task<bool> AddWorryAsync(Worry worry)
    {
      throw new NotImplementedException();
    }

    public Task<bool> AddReplyAsync(Worry worry, Reply reply)
    {
      throw new NotImplementedException();
    }
  }
}