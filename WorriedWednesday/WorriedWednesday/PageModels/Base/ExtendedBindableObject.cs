using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace WorriedWednesday.PageModels.Base
{

  //made extended bindable object in order to apply this to not just page models, but other models too (like buttons)
  public class ExtendedBindableObject : BindableObject
  {
    protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
    {
      if (EqualityComparer<T>.Default.Equals(storage, value))
      {
        return false;
      }
      storage = value;
      OnPropertyChanged(propertyName);
      return true;
    }
    ///  <summary>
    ///   Simplifies the process of updating a Bindable Property and calling INotifyPropertyChanged
    ///  </summary>
    ///  <typeparam name="T"></typeparam>
    ///  <param name="storage"></param>
    ///  <param name="value"></param>
    ///  <param name="propertyName"></param>
    ///  <returns></returns>

  }
}
