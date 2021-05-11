using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorriedWednesday.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ReadOthersPage : ContentPage
  {
    IAuth auth;
    public ReadOthersPage()
    {
      InitializeComponent();
      auth = DependencyService.Get<IAuth>();
    }
    protected override async void OnAppearing()
    {
      base.OnAppearing();
      if (!auth.IsSignIn())
      {
        Console.WriteLine("BOOOOOOOOOOOOOOOO");
        await Task.Delay(300);
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
      }
      else
      {
        Console.WriteLine("YAYYYYYYYYYYYYY");
      }
    }
    async void OnSignOutButtonClicked(object sender, EventArgs e)
    {
      auth.SignOut();
      await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
  }
}
