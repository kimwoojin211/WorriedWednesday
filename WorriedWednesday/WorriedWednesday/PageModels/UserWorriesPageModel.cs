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
using System.Runtime.CompilerServices;

namespace WorriedWednesday.PageModels
{
  public class UserWorriesPageModel : PageModelBase
  {

    string _text;
    DateTime _timestamp;
    ObservableCollection<Worry> _worries;
    Worry _selectedWorry;
    //List<Worry> _worries;
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

    //public List<Worry> Worries
    public ObservableCollection<Worry> Worries
    {
      get => _worries;
      set => SetProperty(ref _worries, value);
    }

    public Worry SelectedWorry
    {
      get => _selectedWorry;
      set => SetProperty(ref _selectedWorry, value);
        //if(_selectedWorry != null)
        //{ 
        //  Task.Run(() => SelectedAction());
        //}
    }

    public ButtonModel WriteWorryButtonModel
    {
      get => _writeWorryButtonModel;
      set => SetProperty(ref _writeWorryButtonModel, value);
    }

    private async void SelectedAction()
    {
      await _navigationService.NavigateToAsync<WorryDetailsPageModel>(SelectedWorry);
      //Worries.Insert(0, new Worry { Text, Timestamp, Replies, UserId }
    }

    private async void WriteAction()
    {
      await _navigationService.NavigateToAsync<WriteMessagePageModel>();
      //Worries.Insert(0, new Worry { Text, Timestamp, Replies, UserId }
    }


    public override async Task InitializeAsync(object navigationData)
    {
      SelectedWorry = null;
      var user = await _accountService.GetUserAsync();
      Worries = new ObservableCollection<Worry>(user.Worries);

      //List<Worry> worryList =  await _allWorriesService.GetWorriesAsync();
      //Worries = new ObservableCollection<Worry>(worryList);

      await base.InitializeAsync(navigationData);
    }
  }
}
