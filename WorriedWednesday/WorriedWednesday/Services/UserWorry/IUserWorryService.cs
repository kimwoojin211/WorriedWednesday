using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WorriedWednesday.Models;

namespace WorriedWednesday.Services.UserWorry
{
  public interface IUserWorryService
  {
    Task<bool> LogWorryAsync(Worry worry);
    Task<ObservableCollection<Worry>> GetWorriesAsync();
  }
}
