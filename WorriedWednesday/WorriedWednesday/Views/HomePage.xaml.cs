using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WorriedWednesday.Services;
using WorriedWednesday.Pages;

namespace WorriedWednesday.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class HomePage : ContentPage
  {
    IAuth auth;

    public HomePage()
    {
      InitializeComponent();
      auth = DependencyService.Get<IAuth>();
    }

    protected override async void OnAppearing()
    {
      base.OnAppearing();
      if (auth.IsSignIn())
      {
        await Task.Delay(300);
      }
    }

    async void OnLogInButtonClicked(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new LoginPage());
    }
  }
}
