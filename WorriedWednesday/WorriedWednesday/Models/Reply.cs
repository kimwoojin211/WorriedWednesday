using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WorriedWednesday.Models
{
  public class Reply
  {
    public string Message { get; set; }
    public string AuthorId { get; set; } // so when user is trying to read messages, they don't get their own
  }
}