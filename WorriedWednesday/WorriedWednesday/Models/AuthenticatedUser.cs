using System;
using System.Collections.Generic;
using System.Text;

namespace WorriedWednesday.Models
{
  public class AuthenticatedUser
  {

    public string Id { get; set; }
    public List<Worry> Worries { get; set; }
  }
}
  