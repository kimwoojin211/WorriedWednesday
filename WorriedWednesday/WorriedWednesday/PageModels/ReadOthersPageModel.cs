﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorriedWednesday.Models;
using WorriedWednesday.PageModels.Base;
using WorriedWednesday.Services;
using WorriedWednesday.Services.Account;
using WorriedWednesday.Services.AllWorries;
using WorriedWednesday.Services.Navigation;
using WorriedWednesday.ViewModels.Buttons;

namespace WorriedWednesday.PageModels
{
  public class ReadOthersPageModel : PageModelBase
  {
    string _name, _message;
    ButtonModel _replyButtonModel,
              _writeWorryButtonModel,
              _nextWorryButtonModel,
              _prevWorryButtonModel,
              _randomWorryButtonModel;
    List<Worry> _othersWorries;
    Worry _currentWorry;
    INavigationService _navigationService;
    IAllWorriesService _allWorriesService;
    IAccountService _accountService;
    Random _randomGenerator;

    public ReadOthersPageModel(INavigationService navigationService,
                                IAllWorriesService allWorriesService,
                                IAccountService accountService)
    {
      _navigationService = navigationService;
      _accountService = accountService;
      _allWorriesService = allWorriesService;
      _randomGenerator = new Random();
      ReplyButtonModel = new ButtonModel("Reply", ReplyAction);
      WriteWorryButtonModel = new ButtonModel("New Worry", WriteAction);
      PrevWorryButtonModel = new ButtonModel("Prev Worry", PrevWorryAction);
      NextWorryButtonModel = new ButtonModel("Next Worry", NextWorryAction);
      RandomWorryButtonModel = new ButtonModel("Random Worry", RandomWorryAction);
    }

    //public properties
    public string Message
    {
      get => _message;
      set => SetProperty(ref _message, value);
    }

    public string Name
    {
      get => _name;
      set => SetProperty(ref _name, value);
    }

    public Worry CurrentWorry
    {
      get => _currentWorry;
      set => SetProperty(ref _currentWorry, value);
    }

    public string AuthUser
    {
      get => _message;
      set => SetProperty(ref _message, value);
    }

    //button models

    public ButtonModel ReplyButtonModel
    {
      get => _replyButtonModel;
      set => SetProperty(ref _replyButtonModel, value);
    }

    public ButtonModel WriteWorryButtonModel
    {
      get => _writeWorryButtonModel;
      set => SetProperty(ref _writeWorryButtonModel, value);
    }

    public ButtonModel PrevWorryButtonModel
    {
      get => _prevWorryButtonModel;
      set => SetProperty(ref _prevWorryButtonModel, value);
    }

    public ButtonModel NextWorryButtonModel
    {
      get => _nextWorryButtonModel;
      set => SetProperty(ref _nextWorryButtonModel, value);
    }

    public ButtonModel RandomWorryButtonModel
    {
      get => _randomWorryButtonModel;
      set => SetProperty(ref _randomWorryButtonModel, value);
    }

    //button actions
    private async void WriteAction()
    {
      await _navigationService.NavigateToAsync<WriteMessagePageModel>();
    }

    private async void ReplyAction()
    {
      await _navigationService.NavigateToAsync<WriteMessagePageModel>(CurrentWorry);
    }

    private void PrevWorryAction()
    {
      int index = _othersWorries.FindIndex(worry => worry.Equals(CurrentWorry));
      if (index == 0 && NextWorryButtonModel.IsEnabled)
      {
        CurrentWorry = _othersWorries[_othersWorries.Count-1];
      }
      else
      {
        CurrentWorry = _othersWorries[--index];
      }
    }

    private void NextWorryAction()
    {
      int index = _othersWorries.FindIndex(worry => worry.Equals(CurrentWorry));
      if (index == _othersWorries.Count-1)
      {
        CurrentWorry = _othersWorries[0];
      }
      else
      {
        CurrentWorry = _othersWorries[++index];
      }
    }

    private void RandomWorryAction()
    {
      int index = _othersWorries.FindIndex(worry => worry.Equals(CurrentWorry));
      int randomIndex = _randomGenerator.Next(_othersWorries.Count);
      while(index == randomIndex)
      {
        randomIndex = _randomGenerator.Next(_othersWorries.Count);
      }
      CurrentWorry = _othersWorries[randomIndex];
    }

    public override async Task InitializeAsync(object navigationData)
    {

      //var item = await PageModelLocator.Resolve<IRepository<TestData>>().Get("9PibxRDmDZTNOWIRIUWk");
      //if (item != null)
      //{
      //}
      var user = await _accountService.GetUserAsync();

      _othersWorries = await _allWorriesService.GetWorriesAsync();
      _othersWorries.RemoveAll(worry => worry.AuthorId == user.Id);
      _othersWorries.RemoveAll(worry => worry.Replies.FindIndex(reply => reply.AuthorId == user.Id) != -1);

      if(!_othersWorries.Any())
      {
        CurrentWorry = new Worry
        {
          Message = "No new Worries!"
        };

        PrevWorryButtonModel.IsEnabled = false;
        NextWorryButtonModel.IsEnabled = false;
        RandomWorryButtonModel.IsEnabled = false;
        ReplyButtonModel.IsEnabled = false;
      }
      else
      {
        CurrentWorry = _othersWorries[0]; 
        ReplyButtonModel.IsEnabled = true;  

        if (_othersWorries.Count == 1)
        {
          PrevWorryButtonModel.IsEnabled = false;
          NextWorryButtonModel.IsEnabled = false;
          RandomWorryButtonModel.IsEnabled = false;
        }
        else
        {
          PrevWorryButtonModel.IsEnabled = true;
          NextWorryButtonModel.IsEnabled = true;
          RandomWorryButtonModel.IsEnabled = true;
        }
      }

      await base.InitializeAsync(navigationData);
    } 
  }
}
