
using Firebase.Auth;
using Firebase.Firestore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorriedWednesday.Droid.ServiceListeners;
using WorriedWednesday.Droid.Services;
using WorriedWednesday.Models;
using WorriedWednesday.Services.Account;
using WorriedWednesday.Services.AllWorries;
using Xamarin.Forms;

[assembly: Dependency(typeof(AllWorriesService))]
namespace WorriedWednesday.Droid.Services
{
  public class AllWorriesService : IAllWorriesService
  {
    public AllWorriesService()
    {
    }
    public Task<bool> LogWorryAsync(Worry worry)
    {
      var tcs = new TaskCompletionSource<bool>();
      return tcs.Task;
    }
    public Task<List<Worry>> GetWorriesAsync()
    {
      var tcs = new TaskCompletionSource<List<Worry>>();
      Android.Gms.Tasks.Task task = FirebaseFirestore.Instance.Collection("worries").Document("RecentWorries").Get().AddOnCompleteListener(new OnWorryCompleteListener(tcs));
      return tcs.Task;
    }
  }
}