using System.Collections.Generic;

namespace WorriedWednesday.Models
{
  public class AuthenticatedUser
  {
    // current logged in user's Id
    public string Id { get; set; }

    public string Name { get; set; }
    // users list of worries
    public List<Worry> Worries { get; set; }
  }
}
  