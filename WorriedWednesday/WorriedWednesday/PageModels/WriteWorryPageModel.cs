using System;
using System.Collections.Generic;
using System.Text;
using WorriedWednesday.PageModels;
using WorriedWednesday.PageModels.Base;
using WorriedWednesday.Services.Navigation;
using WorriedWednesday.ViewModels.Buttons;

namespace WorriedWednesday
{
  public class WriteWorryPageModel : PageModelBase
  {
    string _text;
    ButtonModel _submitButtonModel;
    INavigationService _navigationService;
    public WriteWorryPageModel(INavigationService navigationService)
    {

      _navigationService = navigationService;
      SubmitButtonModel = new ButtonModel("Submit", SubmitAction);
    }

    public string Text
    {
      get => _text;
      set => SetProperty(ref _text, value);
    }

    public ButtonModel SubmitButtonModel
    {
      get => _submitButtonModel;
      set => SetProperty(ref _submitButtonModel, value);
    }
    private async void SubmitAction()
    {
      await _navigationService.NavigateToAsync<DashboardPageModel>();
    }
  }
}