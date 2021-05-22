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
    bool _isReply;
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
      SubmitButtonModel = new ButtonModel("Submit", VerifySubmissionAction);
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

    public bool IsReply
    {
      get => _isReply;
      set => SetProperty(ref _isReply, value);
    }

    async void VerifySubmissionAction()
    {
      string warningMessage = Worry != null ?
        "Once you submit a reply, you will no longer be able to read this worry or edit/delete your reply." : 
        "Once you submit a worry, you will not be able to edit or delete it from the public space.";
      bool answer = await App.Current.MainPage.DisplayAlert("Warning!", warningMessage + " Would you like to continue?", "Yes", "No");
      if (answer)
      {
        SubmitAction();
      }
    }

    async void SubmitAction()
    {
      if (Worry != null)
      {
        var item = new Reply
        {
          Message = Message,
          AuthorId = Id
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
          AuthorId = Id
        };
        await _accountService.AddWorryAsync(item);
        await _allWorriesService.LogWorryAsync(item);
      }

      await _navigationService.NavigateToAsync<DashboardPageModel>();
    }

    public override async Task InitializeAsync(object navigationData)
    {
      var user = await _accountService.GetUserAsync();
      if(user != null)
      {
        Id = user.Id;
      }
      if(navigationData is Worry worry)
      {
        Worry = worry;
        IsReply = true;
      }
      else
      {
        IsReply = false;
      }
      await base.InitializeAsync(navigationData);
    }
  }
}