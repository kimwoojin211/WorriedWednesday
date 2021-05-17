using System;
using System.Collections.Generic;
using System.Text;
using WorriedWednesday.Models;
using WorriedWednesday.PageModels;
using WorriedWednesday.PageModels.Base;
using WorriedWednesday.Services.Navigation;
using WorriedWednesday.Services.UserWorry;
using WorriedWednesday.ViewModels.Buttons;

namespace WorriedWednesday
{
  public class WriteWorryPageModel : PageModelBase
  {
    string _message;
    ButtonModel _submitButtonModel;
    INavigationService _navigationService;
    IUserWorryService _userWorryService;
    public WriteWorryPageModel(INavigationService navigationService, 
                                IUserWorryService userWorryService)
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

    public ButtonModel SubmitButtonModel
    {
      get => _submitButtonModel;
      set => SetProperty(ref _submitButtonModel, value);
    }
    private async void SubmitAction()
    {
      //Timestamp = DateTime.Now
      Console.WriteLine(Message);
      var item = new Worry
      {
        Message = Message,
        Timestamp = DateTime.Now,
        Replies = new List<string>(),
        userId = "1"
      };
      //Worries.Insert(0, new Worry { Message, Timestamp, Replies, UserId }
      await _userWorryService.LogWorryAsync(item);
      await _navigationService.NavigateToAsync<DashboardPageModel>();
    }
  }
}