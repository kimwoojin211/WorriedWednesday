using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WorriedWednesday.Models;

namespace WorriedWednesday.Services.AllWorries
{
  public class MockAllWorriesService : IAllWorriesService
  {
    public List<Worry> Worries { get; set; }
    public MockAllWorriesService()
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
