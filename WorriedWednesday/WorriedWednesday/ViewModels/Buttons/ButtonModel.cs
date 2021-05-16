using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WorriedWednesday.PageModels.Base;
using Xamarin.Forms;

namespace WorriedWednesday.ViewModels.Buttons
{
  public class ButtonModel : ExtendedBindableObject
  {
    string _text;
    bool _isVisible;
    bool _isEnabled;
    ICommand _command;

    //2 different constructors, one to handle commands, one to handle actions
    public ButtonModel(string text, ICommand command, bool isVisible = true, bool isEnabled = true)
    {
      Text = text;
      Command = command;
      IsVisible = isVisible;
      IsEnabled = isEnabled;
    }

    public ButtonModel(string text, Action action, bool isVisible = true, bool isEnabled = true)
    {
      Text = text;
      Command = new Command(action);
      IsVisible = isVisible;
      IsEnabled = isEnabled;
    }

    public string Text
    {
      get => _text;
      set => SetProperty(ref _text, value);

    }

    public bool IsVisible
    {
      get => _isVisible;
      set => SetProperty(ref _isVisible, value);
    }

    public bool IsEnabled
    {
      get => _isEnabled;
      set => SetProperty(ref _isEnabled, value);
    }

    public ICommand Command
    {
      get => _command;
      set => SetProperty(ref _command, value);
    }
  }
}
