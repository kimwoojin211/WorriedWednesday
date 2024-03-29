﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorriedWednesday.PageModels.Base;
using WorriedWednesday.Pages;
using Xamarin.Forms;

namespace WorriedWednesday.Services.Navigation
{
  public class NavigationService : INavigationService
  {

    public async Task NavigateToAsync<TPageModel>(object navigationData = null, bool setRoot = false)
            where TPageModel : PageModelBase 
    {
      Page page = PageModelLocator.CreatePageFor<TPageModel>();
      if (setRoot)
      {
        if(page is TabbedPage tabbedPage)
        {
          App.Current.MainPage = tabbedPage;
        }
        else if(page is LoginPage loginpage)
        {
          App.Current.MainPage = loginpage;
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
        else if (App.Current.MainPage is TabbedPage tabbedPage)
        {
          if (tabbedPage.CurrentPage is NavigationPage nPage)
          {
            await nPage.PushAsync(page);
          }
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
    public Task GoBackAsync()
    {
      if (App.Current.MainPage is NavigationPage navPage)
      {
        return navPage.PopAsync();
      }
      return Task.CompletedTask;
    }
  }
}
