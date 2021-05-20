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
    public Task<bool> LogWorryAsync(Worry worryInput)
    {

      Worries.Insert(0,worryInput);
      return Task.FromResult(true);
    }
    public Task<List<Worry>> GetWorriesAsync()
    {
      return Task.FromResult(Worries);
    }
  }
}
