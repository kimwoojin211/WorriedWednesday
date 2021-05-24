using System;
using System.Collections.Generic;


namespace WorriedWednesday.Models
{
  public class Worry
  {
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }
    public List<Reply> Replies { get; set; }
    public string AuthorId { get; set; }
  }
} 