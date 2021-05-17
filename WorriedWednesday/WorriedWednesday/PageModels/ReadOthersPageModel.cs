using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorriedWednesday.Models;
using WorriedWednesday.PageModels.Base;
using WorriedWednesday.Services.AllWorries;
using WorriedWednesday.Services.Navigation;
using WorriedWednesday.ViewModels.Buttons;

namespace WorriedWednesday.PageModels
{
  public class ReadOthersPageModel : PageModelBase
  {
    string _username, _message;
    ButtonModel _replyButtonModel, _writeWorryButtonModel;
    List<Worry> _othersWorries;
    Worry _currentWorry;
    INavigationService _navigationService;
    IAllWorriesService _allWorriesService;

    public ReadOthersPageModel(INavigationService navigationService,
                                IAllWorriesService allWorriesService)
    {
      _navigationService = navigationService;
      _allWorriesService = allWorriesService;
      ReplyButtonModel = new ButtonModel("Reply", ReplyAction);
      WriteWorryButtonModel = new ButtonModel("New Worry", WriteAction);
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

    public Worry CurrentWorry
    {
      get => _currentWorry;
      set => SetProperty(ref _currentWorry, value);
    }

    //public ObservableCollection<Worry> OthersWorries
    //{
    //  get => _othersWorries;
    //  set => SetProperty(ref _othersWorries, value);
    //}

    private void ReplyAction()
    {
      //navigate to write reply page
      //or just make it so that a text input pop up comes up
      //or something
      throw new NotImplementedException();
    }
    private async void WriteAction()
    {
      await _navigationService.NavigateToAsync<WriteWorryPageModel>();
    }

    public override async Task InitializeAsync(object navigationData)
    {
      ObservableCollection<Worry> temp = await _allWorriesService.GetWorriesAsync();
      _othersWorries = temp.ToList();
      Console.WriteLine("SURVEY SAYS: " + _othersWorries.Any());
      if (_othersWorries.Any())
      {
        Console.WriteLine("~*~*~        **~*~" + _othersWorries[0] + "~*~~*~         **~~**~~*");

        CurrentWorry = _othersWorries[0];
        Console.WriteLine(CurrentWorry.Message);

      }
      await base.InitializeAsync(navigationData);
    } 
  }
}
