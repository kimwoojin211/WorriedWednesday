﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorriedWednesday.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class SettingsPage : ContentPage
  {
    IAuth auth;

    public SettingsPage()
    {
      InitializeComponent();
      auth = DependencyService.Get<IAuth>();
    }
    async void OnSignOutButtonClicked(object sender, EventArgs e)
    {
      auth.SignOut();
      await Navigation.PushAsync(new LoginPage());
    }
  }
}