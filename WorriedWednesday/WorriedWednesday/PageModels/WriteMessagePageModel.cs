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

namespace WorriedWednesday
{
  public class WriteMessagePageModel : PageModelBase
  {
    Worry _worry;
    string _message, _id;
    ButtonModel _submitButtonModel;
    INavigationService _navigationService;
    IAllWorriesService _allWorriesService;
    public WriteMessagePageModel(INavigationService navigationService,
                                IAllWorriesService allWorriesService)
    {
      _allWorriesService = allWorriesService;
      _navigationService = navigationService;
      SubmitButtonModel = new ButtonModel("Submit", SubmitAction);
    }


    public string Message
    {
      get => _message;
      set => SetProperty(ref _message, value);
    }

    // manually enter id so i know which post belongs to which account until i can get accountservice working
    public string Id
    {
      get => _id;
      set => SetProperty(ref _id, value);
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
          userId = Id
        };
        Worry.Replies.Add(item);
        await _allWorriesService.LogWorryAsync(Worry);
      }
      else
      {
        var item = new Worry
        {
          Message = Message,
          Timestamp = DateTime.Now,
          Replies = new List<Reply>(),
          userId = Id
        };
        await _allWorriesService.LogWorryAsync(item);
      }

      await _navigationService.NavigateToAsync<DashboardPageModel>();
    }

    public override async Task InitializeAsync(object navigationData)
    {
      if(navigationData is Worry worry)
      {
        Worry = worry;
      }
      await base.InitializeAsync(navigationData);
    }
  }
}