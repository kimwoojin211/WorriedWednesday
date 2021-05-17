using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WorriedWednesday.Models;

namespace WorriedWednesday.Services.UserWorry
{
  public class MockUserWorryService : IUserWorryService
  {
    public List<Worry> Worries { get; set; }
    public MockUserWorryService()
    {
      Worries = new List<Worry>();
    }
    public Task<bool> LogWorryAsync(Worry worry)
    {
      Worries.Insert(0,worry);
      return Task.FromResult(true);
    }
    public Task<ObservableCollection<Worry>> GetWorriesAsync()
    {
      return Task.FromResult(new ObservableCollection<Worry>(Worries));
    }
  }
}
