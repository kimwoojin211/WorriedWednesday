using System.Collections.Generic;
using System.Threading.Tasks;
using WorriedWednesday.Models;
using WorriedWednesday.PageModels.Base;
using WorriedWednesday.Services.Navigation;

namespace WorriedWednesday.PageModels
{
  public class WorryDetailsPageModel : PageModelBase
  {
    Worry _selectedWorry;
    List<Reply> _replies;
    INavigationService _navigationService;
    public WorryDetailsPageModel(INavigationService navigationService)
    {
      _navigationService = navigationService;
    }

    public Worry SelectedWorry
    {
      get => _selectedWorry;
      set => SetProperty(ref _selectedWorry, value);
    }
    public List<Reply> Replies
    {
      get => _replies;
      set => SetProperty(ref _replies, value);
    }

    public override async Task InitializeAsync(object navigationData)
    {
      SelectedWorry = (Worry)navigationData;
      Replies = SelectedWorry.Replies;
      await base.InitializeAsync(navigationData);
    }
  }
}
