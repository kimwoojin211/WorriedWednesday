using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WorriedWednesday.Models
{
  public class Worry
  {
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }
    public List<string> Replies { get; set; }
    public string userId { get; set; } // so when user is trying to read messages, they don't get their own
  }
}