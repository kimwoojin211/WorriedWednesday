using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WorriedWednesday.Models;
using WorriedWednesday.PageModels.Base;
using WorriedWednesday.Services.Account;
using WorriedWednesday.Services.Navigation;
using WorriedWednesday.Services.AllWorries;
using WorriedWednesday.ViewModels.Buttons;
using System.Runtime.CompilerServices;
using Xamarin.CommunityToolkit;
using System.Windows.Input;
using Xamarin.Forms;

namespace WorriedWednesday.PageModels
{
  public class UserWorriesPageModel : PageModelBase 
  {

    string _text;
    DateTime _timestamp;
    ObservableCollection<Worry> _worries;
    Worry _selectedWorry;
    ButtonModel _writeWorryButtonModel;
    INavigationService _navigationService;
    IAccountService _accountService;
    ICommand _itemTappedCommand;
    public UserWorriesPageModel(INavigationService navigationService, 
                                IAccountService accountService)
    {
      _accountService = accountService;
      _navigationService = navigationService;
      WriteWorryButtonModel = new ButtonModel("New Worry", WriteAction);
      ItemTappedCommand = new Command((selectedWorry) =>
      {
        SelectedAction(selectedWorry);
      });
    }

    //public properties
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

    public ObservableCollection<Worry> Worries
    {
      get => _worries;
      set => SetProperty(ref _worries, value);
    }

    public Worry SelectedWorry
    {
      get => _selectedWorry;
      set => SetProperty(ref _selectedWorry, value);
    }

    public ButtonModel WriteWorryButtonModel
    {
      get => _writeWorryButtonModel;
      set => SetProperty(ref _writeWorryButtonModel, value);
    }


    public ICommand ItemTappedCommand
    {
      get => _itemTappedCommand;
      set => SetProperty(ref _itemTappedCommand, value);
    }


    private async void SelectedAction(object selectedWorry)
    {
      await _navigationService.NavigateToAsync<WorryDetailsPageModel>((Worry) selectedWorry);
    }

    private async void WriteAction()
    {
      await _navigationService.NavigateToAsync<WriteMessagePageModel>();
    }


    public override async Task InitializeAsync(object navigationData)
    {
      SelectedWorry = null;
      var user = await _accountService.GetUserAsync();
      Worries = new ObservableCollection<Worry>(user.Worries);
      await base.InitializeAsync(navigationData);
    }
  }
}
