using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WorriedWednesday.Models;
using WorriedWednesday.PageModels.Base;

namespace WorriedWednesday.PageModels
{
  public class UserWorriesPageModel : PageModelBase
  {

    string _text;
    DateTime _timestamp;
    ObservableCollection<Worry> _worries;
    public UserWorriesPageModel()
    {
      Worries = new ObservableCollection<Worry>();
    }
    public string Text
    {
      get => _text;
      set => SetProperty(ref _text, value);
    }
    
    public DateTime Timestamp
    {
      get => _timestamp;
      set => SetProperty(ref _timestamp, value);
    }

    public ObservableCollection<Worry> Worries
    {
      get => _worries;
      set => SetProperty(ref _worries, value);
    }
    public override Task InitializeAsync(object navigationData)
    {
      return base.InitializeAsync(navigationData);
    }

  }
}
