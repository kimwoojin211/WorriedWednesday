using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WorriedWednesday.Models;
using WorriedWednesday.PageModels.Base;
using WorriedWednesday.Services.Account;
using WorriedWednesday.Services.Navigation;
using WorriedWednesday.Services.AllWorries;
using WorriedWednesday.ViewModels.Buttons;

namespace WorriedWednesday.PageModels
{
  public class UserWorriesPageModel : PageModelBase
  {

    string _text;
    DateTime _timestamp;
    //ObservableCollection<Worry> _worries;
    List<Worry> _worries;
    ButtonModel _writeWorryButtonModel;
    INavigationService _navigationService;
    IAccountService _accountService;
    IAllWorriesService _allWorriesService;
    public UserWorriesPageModel(INavigationService navigationService, 
                                IAccountService accountService, 
                                IAllWorriesService allWorriesService)
    {
      _accountService = accountService;
      _allWorriesService = allWorriesService;
      _navigationService = navigationService;
      WriteWorryButtonModel = new ButtonModel("New Worry", WriteAction);
    }
    public string Text
    {
      get => _text;
      set => SetProperty(ref _text, value);
    }
    
    public DateTime Timestamp
    {
      get => _timestamp;
      set => SetProperty(ref _timestamp, value);
    }

    //public ObservableCollection<Worry> Worries
    public List<Worry> Worries
    {
      get => _worries;
      set => SetProperty(ref _worries, value);
    }
    public ButtonModel WriteWorryButtonModel
    {
      get => _writeWorryButtonModel;
      set => SetProperty(ref _writeWorryButtonModel, value);
    }
    private async void WriteAction()
    {
      await _navigationService.NavigateToAsync<WriteWorryPageModel>();
      //Worries.Insert(0, new Worry { Text, Timestamp, Replies, UserId }
    }
    public override async Task InitializeAsync(object navigationData)
    {
      Console.WriteLine("                                  sheeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee~~~~~~~~~~~~~~~          1");
      var user = await _accountService.GetUserAsync();
      Console.WriteLine("                                  sheeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee~~~~~~~~~~~~~~~          2");
      Worries = user.Worries;

      Console.WriteLine("                                  sheeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee~~~~~~~~~~~~~~~          3");
      await base.InitializeAsync(navigationData);
    }

  }
}
