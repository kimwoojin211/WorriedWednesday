﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WorriedWednesday.Services;

namespace WorriedWednesday.Pages
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class LoginPage : ContentPage
  {
    IAuth auth;
    public LoginPage()
    {
      InitializeComponent();
      auth = DependencyService.Get<IAuth>();
    }


    void RegisterLabel_Tapped(object sender, EventArgs args)
    {
      registerStackLayout.IsVisible = true;
      loginStackLayout.IsVisible = false;
    }

    void LoginLabel_Tapped(object sender, EventArgs args)
    {
      registerStackLayout.IsVisible = false;
      loginStackLayout.IsVisible = true;
    }
  }
}