using System.Windows.Input;
using WorriedWednesday.PageModels.Base;
using WorriedWednesday.Services.Account;
using WorriedWednesday.Services.Navigation;
using Xamarin.Forms;

// to test with active firebase auth database, use
// email = test@test.com
// password = 123456

namespace WorriedWednesday.PageModels
{
  public class LoginPageModel : PageModelBase
  {
    //private fields
    ICommand _loginCommand, _registerCommand, _passwordResetCommand;
    INavigationService _navigationService;
    IAccountService _accountService;
    string _name, _email, _password, _confirmPassword;

    //constructor
    public LoginPageModel(INavigationService navigationService, IAccountService accountService)
    {
      _navigationService = navigationService;
      _accountService = accountService;
      LoginCommand = new Command(DoLoginAction);
      RegisterCommand = new Command(DoRegisterAction);
      PasswordResetCommand = new Command(DoPasswordResetAction);
    }

    //public properties
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

    //commands

    public ICommand LoginCommand
    { get => _loginCommand;
      set => SetProperty(ref _loginCommand, value);
    }

    public ICommand RegisterCommand
    {
      get => _registerCommand;
      set => SetProperty(ref _registerCommand, value);
    }

    public ICommand PasswordResetCommand
    {
      get => _passwordResetCommand;
      set => SetProperty(ref _passwordResetCommand, value);
    }

    //async actions
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
      if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
      {
        await App.Current.MainPage.DisplayAlert("Error", "Please fill out all information", "Ok");
      }
      else if (ConfirmPassword != Password)
      {
        //Display failure alert
        await App.Current.MainPage.DisplayAlert("Error", "Passwords do not match", "Ok");
      }
      else
      {
        var registerAttempt = await _accountService.RegisterAsync(Name, Email, Password);
        if (registerAttempt)
        {
          // clears entry fields. otherwise, if someone logs in and logs back out, previously entered fields still there
          Name = string.Empty;
          Email = string.Empty;
          Password = string.Empty;
          ConfirmPassword = string.Empty;
          await _navigationService.NavigateToAsync<DashboardPageModel>();
        }
        else
        {
          await App.Current.MainPage.DisplayAlert("Error", "Email is already in use. Please use another email", "Ok");
        }
      }
    }

    async void DoPasswordResetAction()
    { 
      var resetAttempt = await _accountService.PasswordResetAsync(Email);
      if (resetAttempt)
      {
        await App.Current.MainPage.DisplayAlert("Success!", "Please check your e-mail for further instructions", "Ok");
      }
      else
      {
        //Display failure alert
        await App.Current.MainPage.DisplayAlert("Error", "Error. Please try again", "Ok");
      }
    }
  }

    // unneeded because of ExtendedBindableObject's SetProperty()

    //void OnPropertyChanged(string propertyName)
    //{
    //  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //}

}
