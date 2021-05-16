using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WorriedWednesday.PageModels.Base
{
  public class PageModelBase : ExtendedBindableObject
  {
    string _title;
    bool _isLoading;

    //title of page 
    public string Title
    {
      get => _title;
      set => SetProperty(ref _title, value);
    }


    public bool IsLoading
    {
      get => _isLoading;
      set => SetProperty(ref _isLoading, value);
    }


    public virtual Task InitializeAsync(object navigationData = null)
    {
      return Task.CompletedTask;
    }

    //moved to extended bindable object

    //protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
    //{
    //  if (EqualityComparer<T>.Default.Equals(storage, value))
    //  {
    //    return false;
    //  }

    //  storage = value;
    //  OnPropertyChanged(propertyName);
    //  return true;
    //}

  }
}
