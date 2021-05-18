using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
    string _username, _message;
    ButtonModel _replyButtonModel,
              _writeWorryButtonModel,
              _nextWorryButtonModel,
              _prevWorryButtonModel,
              _randomWorryButtonModel;
    List<Worry> _othersWorries;
    Worry _currentWorry;
    INavigationService _navigationService;
    IAllWorriesService _allWorriesService;
    Random _randomGenerator;
    IAccountService _accountService;

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

    public string Message
    {
      get => _message;
      set => SetProperty(ref _message, value);
    }

    public string Username
    {
      get => _username;
      set => SetProperty(ref _username, value);
    }

    public Worry CurrentWorry
    {
      get => _currentWorry;
      set => SetProperty(ref _currentWorry, value);
    }

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

    private void ReplyAction()
    {
      //navigate to write reply page
      //or just make it so that a text input pop up comes up
      //or something
    }
    private async void WriteAction()
    {
      await _navigationService.NavigateToAsync<WriteWorryPageModel>();
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

      Console.WriteLine("                                   siiiiiiiiiiick~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~          1");
      //var items = await PageModelLocator.Resolve<IRepository<TestData>>().GetAll();
      //if (items != null)
      //{

      //}
      _othersWorries = await _allWorriesService.GetWorriesAsync();
      Console.WriteLine(_othersWorries.Any() + "                                   siiiiiiiiiiick~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~          2");
      var user = await _accountService.GetUserAsync();
      Console.WriteLine("                                   siiiiiiiiiiick~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~          3");
      if (user != null)
      {
        Console.WriteLine("                                   siiiiiiiiiiick~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~         4");
      }

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
        ReplyButtonModel.IsEnabled = true ;
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
