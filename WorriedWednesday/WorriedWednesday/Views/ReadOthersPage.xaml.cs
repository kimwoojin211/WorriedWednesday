using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WorriedWednesday.Services;

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
        var user = await auth.GetUserAsync();
        if(user != null)
        {

        }
        await Task.Delay(300);
        await Navigation.PushAsync(new LoginPage()); ;
      }
    }
    //async void OnSignOutButtonClicked(object sender, EventArgs e)
    //{
    //  auth.SignOut();
    //  await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    //}
  }
}
