using System;
using System.Collections.Generic;
using System.Text;
using WorriedWednesday.Models;
using WorriedWednesday.PageModels;
using WorriedWednesday.PageModels.Base;
using WorriedWednesday.Services.Navigation;
using WorriedWednesday.Services.AllWorries;
using WorriedWednesday.ViewModels.Buttons;
using System.Threading.Tasks;
using WorriedWednesday.Services.Account;

namespace WorriedWednesday
{
  public class WriteMessagePageModel : PageModelBase
  {
    Worry _worry;
    string _message, _id;
    ButtonModel _submitButtonModel;
    INavigationService _navigationService;
    IAllWorriesService _allWorriesService;
    IAccountService _accountService;
    public WriteMessagePageModel(IAccountService accountService, 
                                INavigationService navigationService,
                                IAllWorriesService allWorriesService)
    {
      _accountService = accountService;
      _allWorriesService = allWorriesService;
      _navigationService = navigationService;
      SubmitButtonModel = new ButtonModel("Submit", SubmitAction);
    }


    public string Message
    {
      get => _message;
      set => SetProperty(ref _message, value);
    }

    public Worry Worry
    {
      get => _worry;
      set => SetProperty(ref _worry, value);
    }

    public ButtonModel SubmitButtonModel
    {
      get => _submitButtonModel;
      set => SetProperty(ref _submitButtonModel, value);
    }

    private async void SubmitAction()
    {
      if (Worry != null)
      {
        var item = new Reply
        {
          Message = Message,
          AuthorId = _id
        };
        await _accountService.AddReplyAsync(Worry, item);
      }
      else
      {
        var item = new Worry
        {
          Message = Message,
          Timestamp = DateTime.Now,
          Replies = new List<Reply>(),
          AuthorId = _id
        };
        await _allWorriesService.LogWorryAsync(item);
        await _accountService.AddWorryAsync(item);
      }

      await _navigationService.NavigateToAsync<DashboardPageModel>();
    }

    public override async Task InitializeAsync(object navigationData)
    {
      var user = await _accountService.GetUserAsync();
      if(user != null)
      {
        _id = user.Id;
      }
      if(navigationData is Worry worry)
      {
        Worry = worry;
      }
      await base.InitializeAsync(navigationData);
    }
  }
}