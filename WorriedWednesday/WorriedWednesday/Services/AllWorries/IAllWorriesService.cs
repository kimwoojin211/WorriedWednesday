using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WorriedWednesday.Models;

namespace WorriedWednesday.Services.AllWorries
{
  public interface IAllWorriesService
  {
    Task<bool> LogWorryAsync(Worry worry);
    Task<List<Worry>> GetWorriesAsync();
  }
}
