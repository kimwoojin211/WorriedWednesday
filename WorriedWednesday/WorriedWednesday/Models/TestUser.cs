using System;
using System.Collections.Generic;
using System.Text;

namespace WorriedWednesday.Models
{
  public class TestUser
  {
    public TestUser(string id, string name, string email, string password)
    {
      Id = id;
      Name = name;
      Email = email;
      Password = password;
      Worries = new List<Worry>();
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Worry> Worries { get; set; }
  }
}
