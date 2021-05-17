using System;
using System.Collections.Generic;
using System.Text;
using WorriedWednesday.Models;
using WorriedWednesday.PageModels;
using WorriedWednesday.PageModels.Base;
using WorriedWednesday.Services.Navigation;
using WorriedWednesday.Services.AllWorries;
using WorriedWednesday.ViewModels.Buttons;

namespace WorriedWednesday
{
  public class WriteWorryPageModel : PageModelBase
  {
    string _message, _id;
    ButtonModel _submitButtonModel;
    INavigationService _navigationService;
    IAllWorriesService _userWorryService;
    public WriteWorryPageModel(INavigationService navigationService, 
                                IAllWorriesService userWorryService)
    {
      _userWorryService = userWorryService;
      _navigationService = navigationService;
      SubmitButtonModel = new ButtonModel("Submit", SubmitAction);
    }

  
    public string Message
    {
      get => _message;
      set => SetProperty(ref _message, value);
    }

    public string Id
    {
      get => _id;
      set => SetProperty(ref _id, value);
    }
    public ButtonModel SubmitButtonModel
    {
      get => _submitButtonModel;
      set => SetProperty(ref _submitButtonModel, value);
    }
    private async void SubmitAction()
    {
      var item = new Worry
      {
        Message = Message,
        Timestamp = DateTime.Now,
        Replies = new List<string>(),
        userId = Id
      };
      await _userWorryService.LogWorryAsync(item);
      await _navigationService.NavigateToAsync<DashboardPageModel>();
    }
  }
}