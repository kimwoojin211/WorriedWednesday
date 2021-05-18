
using System;
using WorriedWednesday.Droid.Services;
using WorriedWednesday.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(TestDataRepository))]
namespace WorriedWednesday.Droid.Services
{
  public class TestDataRepository : BaseRepository<TestData>
  {
    protected override string DocumentPath =>
      "users/"
      + Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid
      + "/test";
  }
}