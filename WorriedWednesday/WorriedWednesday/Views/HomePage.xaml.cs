using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
      Console.WriteLine("issignin " + auth.IsSignIn());
      if (!auth.IsSignIn())
      {
        await Task.Delay(300);
        await Navigation.PushAsync(new LoginPage());
      }
      else
      {
      }
    }

    void OnButtonClicked(object sender, EventArgs e)
    {
      auth.SignOut();
    }
  }
}
