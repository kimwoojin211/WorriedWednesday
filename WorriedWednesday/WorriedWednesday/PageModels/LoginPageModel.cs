using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using WorriedWednesday.PageModels.Base;
using WorriedWednesday.Services.Account;
using WorriedWednesday.Services.Navigation;
using Xamarin.Forms;

namespace WorriedWednesday.PageModels
{
  public class LoginPageModel : PageModelBase
  {
    ICommand _loginCommand, _registerCommand;
    INavigationService _navigationService;
    IAccountService _accountService;
    string _name, _email, _password, _confirmPassword;
    public LoginPageModel(INavigationService navigationService, IAccountService accountService)
    {
      _navigationService = navigationService;
      _accountService = accountService;
      LoginCommand = new Command(DoLoginAction);
      RegisterCommand = new Command(DoRegisterAction);
    }

    public ICommand LoginCommand
    { get => _loginCommand;
      set => SetProperty(ref _loginCommand, value);
    }
    public ICommand RegisterCommand
    {
      get => _registerCommand;
      set => SetProperty(ref _registerCommand, value);
    }

    async void DoLoginAction()
    {
      var loginAttempt = await _accountService.LoginAsync(Email, Password);
      if(loginAttempt)
      {
        await _navigationService.NavigateToAsync<DashboardPageModel>();
      }
      else
      {
        //Display failure alert
        await App.Current.MainPage.DisplayAlert("Error", "Email/Password not found. Please try again", "Ok");
      }
    }
    async void DoRegisterAction()
    {
      if (ConfirmPassword != Password)
      {
        //Display failure alert
        await App.Current.MainPage.DisplayAlert("Error", "Passwords do not match", "Ok");
      }
      else
      {
        var registerAttempt = await _accountService.RegisterAsync(Name, Email, Password);
        if (registerAttempt)
        {
          Name = string.Empty;
          Email = string.Empty;
          Password = string.Empty;
          ConfirmPassword = string.Empty;
          await _navigationService.NavigateToAsync<DashboardPageModel>();
        }
      }
    }

    // unneeded because of ExtendedBindableObject's SetProperty()

    //void OnPropertyChanged(string propertyName)
    //{
    //  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //}

    public string Name
    {
      get => _name;
      set => SetProperty(ref _name, value);
    }

    public string Email
    {
      get => _email;
      set => SetProperty(ref _email, value);
    }

    public string Password
    {
      get => _password;
      set => SetProperty(ref _password, value);
    }

    public string ConfirmPassword
    {
      get => _confirmPassword;
      set => SetProperty(ref _confirmPassword, value);
    }
  }
}
