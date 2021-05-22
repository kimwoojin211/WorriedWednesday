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
    //List<Worry> _worries;
    ButtonModel _writeWorryButtonModel;
    INavigationService _navigationService;
    IAccountService _accountService;
    IAllWorriesService _allWorriesService;
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

    //populates listview of all user's worries ever submitted
    public ObservableCollection<Worry> Worries
    {
      get => _worries;
      set => SetProperty(ref _worries, value);
    }

    // when user selects a worry from the listview on UserWorriesPage, I want to redirect them to a WorryDetailsPageModel, with SelectedWorry as navigationdata
    // effectively acting as a details page, where i can also list out all relevant replies
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


    public ICommand ItemTappedCommand
    {
      get => _itemTappedCommand;
      set => SetProperty(ref _itemTappedCommand, value);
    }


    private async void SelectedAction(object selectedWorry)
    {
      await _navigationService.NavigateToAsync<WorryDetailsPageModel>((Worry) selectedWorry);
      //Worries.Insert(0, new Worry { Text, Timestamp, Replies, UserId }
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
