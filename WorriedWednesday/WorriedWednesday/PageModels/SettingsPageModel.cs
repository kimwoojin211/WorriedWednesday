using WorriedWednesday.PageModels.Base;
using WorriedWednesday.Services.Navigation;
using WorriedWednesday.ViewModels.Buttons;

namespace WorriedWednesday.PageModels
{
  public class SettingsPageModel : PageModelBase
  {
    ButtonModel _logOutButtonModel;
    INavigationService _navigationService;

    public SettingsPageModel(INavigationService navigationService)
    {
      _navigationService = navigationService;
      LogOutButtonModel = new ButtonModel("Log Out", LogOutAction);
    }

    public ButtonModel LogOutButtonModel
    {
      get => _logOutButtonModel;
      set => SetProperty(ref _logOutButtonModel, value);
    }

    private async void LogOutAction()
    {
      await _navigationService.NavigateToAsync<LoginPageModel>(null,true);
    }
  }
}
