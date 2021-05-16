using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorriedWednesday.PageModels.Base;
using WorriedWednesday.Services.Navigation;
using Xamarin.Forms;

namespace WorriedWednesday.Navigation
{
  public class NavigationService : INavigationService
  {
    public Task GoBackAsync()
    {
      return App.Current.MainPage.Navigation.PopAsync();
    }
    public async Task NavigateToAsync<TPageModelBase>(object navigationData = null, bool setRoot = false)
            where TPageModelBase : PageModelBase 
    {
      Page page = PageModelLocator.CreatePageFor(typeof(TPageModelBase));
      if (setRoot)
      {
        // if page is tabbedpage (a.k.a. dashboardpage), then current active page won't be wrapped as a NavigationPage
        // and therefore doesn't have like. a back button. or something.
        if(page is TabbedPage tabbedPage)
        {
          App.Current.MainPage = tabbedPage;
        }
        else
        { 
          App.Current.MainPage = new NavigationPage(page);
        }
      }
      else
      {
        if(page is TabbedPage tabPage)
        {
          App.Current.MainPage = tabPage;
        }
        else if(App.Current.MainPage is NavigationPage navPage)
        {
          await navPage.PushAsync(page);
        }
        else
        {
          App.Current.MainPage = new NavigationPage(page);
        }
      }

      if(page.BindingContext is PageModelBase pmBase)
      {
        await pmBase.InitializeAsync(navigationData);
      }
    }
  }
}
