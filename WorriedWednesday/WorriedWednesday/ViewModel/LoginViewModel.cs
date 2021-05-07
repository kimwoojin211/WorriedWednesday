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

    void Register(object parameter)
    {

    }

    void Login(object parameter)
    {
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