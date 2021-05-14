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
    ICommand _loginCommand;
    INavigationService _navigationService;
    IAccountService _accountService;
    public LoginPageModel(INavigationService navigationService, IAccountService accountService)
    {
      _navigationService = navigationService;
      _accountService = accountService;
      LoginCommand = new Command(Login);
      //RegisterCommand = new Command(Register);
      //auth = DependencyService.Get<IAuth>();
    }

    public ICommand LoginCommand
    { get => _loginCommand;
      set => SetProperty(ref _loginCommand, value);
    }

    //IAuth auth;
    string _name, _email, _password;

    //public event PropertyChangedEventHandler PropertyChanged;

    //public ICommand RegisterCommand { get; set; }

    //async void Register(object parameter)
    //{
    //  if (ConfirmPassword != Password)
    //  {
    //    await App.Current.MainPage.DisplayAlert("Error", "Passwords do not match", "Ok");
    //  }
    //  else
    //  {
    //    var user = auth.RegisterWithEmailAndPassword(email, password);
    //    if (user != null)
    //    {
    //      Name = string.Empty;
    //      Email = string.Empty;
    //      Password = string.Empty;
    //      ConfirmPassword = string.Empty;
    //      await Shell.Current.GoToAsync($"//{nameof(ReadOthersPage)}");
    //    }
    //  }
    //}

    private async void DoLoginAction()
    {
      var loginAttempt = await _accountService.LoginAsync(Email, Password);
      if(loginAttempt)
      {
        await _navigationService.NavigateToAsync<ReadOthersPageModel>();
      }
      else
      {
        //Display failure alert
      }
    }

    void Login(object parameter)
    {
      //string token = await auth.LoginWithEmailAndPassword(email, password);
      //if (token != string.Empty)
      //{

      //  Email = string.Empty;
      //  Password = string.Empty;
      //  await _navigationService.NavigateToAsync<ReadOthersPageModel>();
      //}
    }
    //  void OnPropertyChanged(string propertyName)
    //  {
    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //  }
    //  public string Name
    //  {
    //    get
    //    {
    //      return name;
    //    }
    //    set
    //    {
    //      name = value;
    //      OnPropertyChanged("Name");
    //    }
    //  }

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

    //  string confirmPassword;
    //  public string ConfirmPassword
    //  {
    //    get
    //    {
    //      return confirmPassword;
    //    }
    //    set
    //    {
    //      confirmPassword = value;
    //    }
    //  }
    //}

  }
}
