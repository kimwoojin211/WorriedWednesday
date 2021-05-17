﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorriedWednesday.Models;

namespace WorriedWednesday.Services.Account
{
  public class MockAccountService :IAccountService
  {
    public Task<bool> LoginAsync(string email, string password)
    {
      if(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
      {
        return Task.FromResult(false);
      }
      return Task.Delay(500).ContinueWith((Task) => true);
    }
    //public Task<bool> LogWorryAsync(Worry worry)
    //{
    //  Worries.Insert(0, worry);
    //  return Task.FromResult(true);
    //}
  }
}