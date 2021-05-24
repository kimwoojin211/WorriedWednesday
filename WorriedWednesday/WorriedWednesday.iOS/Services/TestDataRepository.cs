using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using WorriedWednesday.iOS.Services;
using WorriedWednesday.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(TestDataRepository))]
namespace WorriedWednesday.iOS.Services
{
  public class TestDataRepository : BaseRepository<TestData>
  {
    public override string DocumentPath => 
      "users/" 
      + Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid 
      + "/test";
  }
}