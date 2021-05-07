using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Windows.Input;
using WorriedWednesday.Views;


namespace WorriedWednesday.ViewModel
{
  public class LoginViewModel : INotifyPropertyChanged
  {
    IAuth auth;
    string name, email, password;

    public event PropertyChangedEventHandler PropertyChanged;

    public LoginViewModel()
    {
      LoginCommand = new Command(Login);
      RegisterCommand = new Command(Register);
      auth = DependencyService.Get<IAuth>();
    }
    public ICommand LoginCommand { get; set; }
    public ICommand RegisterCommand { get; set; }

    async void Register(object parameter)
    {
      if (ConfirmPassword != Password)
      {
        await App.Current.MainPage.DisplayAlert("Error", "Passwords do not match", "Ok");
      }
      else
      {
        var user = auth.RegisterWithEmailAndPassword(email, password);
        if (user != null)
        {
          await Application.Current.MainPage.Navigation.PopAsync();
        }
      }
    }

    async void Login(object parameter)
    {
      string token = await auth.LoginWithEmailAndPassword(email, password);
      if (token != string.Empty)
      {
        await Application.Current.MainPage.Navigation.PopAsync();
      }
    }
    void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public string Name
    {
      get
      {
        return name;
      }
      set
      {
        name = value;
        OnPropertyChanged("Name");
      }
    }

    public string Email
    {
      get
      {
        return email;
      }
      set
      {
        email = value;
        OnPropertyChanged("Email");
      }
    }

    public string Password
    {
      get
      {
        return password;
      }
      set
      {
        password = value;
        OnPropertyChanged("Password");

      }
    }

    string confirmPassword;
    public string ConfirmPassword
    {
      get
      {
        return confirmPassword;
      }
      set
      {
        confirmPassword = value;
      }
    }
  }
}