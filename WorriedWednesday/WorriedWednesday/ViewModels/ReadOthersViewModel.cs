using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Windows.Input;
using WorriedWednesday.Views;

namespace WorriedWednesday.ViewModels
{
  class ReadOthersViewModel : INotifyPropertyChanged
  {
    IAuth auth;

    public event PropertyChangedEventHandler PropertyChanged;

    public ReadOthersViewModel()
    {
      auth = DependencyService.Get<IAuth>();
    }

    void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}