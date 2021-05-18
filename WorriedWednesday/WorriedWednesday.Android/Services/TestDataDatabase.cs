
using System;
using WorriedWednesday.Droid.Services;
using WorriedWednesday.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(TestDataDatabase))]
namespace WorriedWednesday.Droid.Services
{
  public class TestDataDatabase : BaseDatabase<TestData>
  {
    protected override string DocumentPath =>
      "users/"
      + Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid
      + "/test";
  }
}