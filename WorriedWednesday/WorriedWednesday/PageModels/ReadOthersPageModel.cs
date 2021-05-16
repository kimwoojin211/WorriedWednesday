using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorriedWednesday.PageModels.Base;
using WorriedWednesday.Services.Navigation;
using WorriedWednesday.ViewModels.Buttons;

namespace WorriedWednesday.PageModels
{
  public class ReadOthersPageModel : PageModelBase
  {
    string _username;
    ButtonModel _replyButtonModel, _writeWorryButtonModel;
    INavigationService _navigationService;

    public ReadOthersPageModel(INavigationService navigationService)
    {
      _navigationService = navigationService;
      ReplyButtonModel = new ButtonModel("Reply", ReplyAction);
      WriteWorryButtonModel = new ButtonModel("Share", WriteAction);
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

    public override Task InitializeAsync(object navigationData)
    {
      return base.InitializeAsync(navigationData);
    } 
  }
}
