//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.ComponentModel;
//using Xamarin.Forms;
//using System.Windows.Input;
//using WorriedWednesday.Views;
//using WorriedWednesday.Services;

//namespace WorriedWednesday.ViewModels
//{
//  class ReadOthersViewModel : INotifyPropertyChanged
//  {
//    string username;

//    IAuth auth;

//    public event PropertyChangedEventHandler PropertyChanged;

//    public ReadOthersViewModel()
//    {
//      auth = DependencyService.Get<IAuth>();
//    }

//    void OnPropertyChanged(string propertyName)
//    {
//      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//    }

//    public string UserName
//    {
//      set
//      {
//        if (!auth.IsSignIn())
//        {
//          username = value;
//          OnPropertyChanged("UserName");
//        }
//      }
//      get
//      {
//        return username;
//      }
//    }
//  }
//}