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
      //AppCenter.Start("ios=6cd00531-72ca-4eba-9b49-a6629366bf76;android=330f9440-d9fd-4016-a6f0-424493225c26;uwp=9f3a59ef-c845-48cf-991b-11b81daec540;windowsdesktop={Your App Secret}", typeof(Analytics), typeof(Crashes));
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
