using System.Collections.Generic;

namespace WorriedWednesday.Models
{
  public class AuthenticatedUser
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public List<Worry> Worries { get; set; }
  }
}
  