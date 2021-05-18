using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WorriedWednesday.PageModels;
using System.Threading.Tasks;
using WorriedWednesday.PageModels.Base;
using WorriedWednesday.Services.Navigation;

namespace WorriedWednesday
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();
    }

    Task InitNavigation()
    {
      var navService = PageModelLocator.Resolve<INavigationService>();
      return navService.NavigateToAsync<LoginPageModel>();
    }

    protected override async void OnStart()
    {
      base.OnStart();
      await InitNavigation();
      base.OnResume();
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
  }
}
