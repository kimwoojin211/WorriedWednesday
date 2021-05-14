using System;
using System.Collections.Generic;
using System.Text;
using TinyIoC;
using WorriedWednesday.Navigation;
using WorriedWednesday.PageModels;
using WorriedWednesday.Services.Navigation;
using WorriedWednesday.Pages;
using Xamarin.Forms;
using WorriedWednesday.Services.Account;

namespace WorriedWednesday.PageModels.Base
{
  public class PageModelLocator
  {
    static TinyIoCContainer _container;
    static Dictionary<Type, Type> _viewLookup;

    static PageModelLocator()
    {
      _container = new TinyIoCContainer();
      _viewLookup = new Dictionary<Type, Type>();

      // register pages and page models
      Register<LoginPageModel, LoginPage>();
      Register<DashboardPageModel, DashboardPage>();
      //Register<ReadOthersPageModel, ReadOthersPage>();
      //Register<ReadRepliesPageModel, ReadRepliesPage>();
      //Register<UserWorriesPageModel, UserWorriesPage>();
      //Register<WriteMessagePageModel, WriteMessagePage>();
      //Register<SettingsPageModel, SettingsPage>();


      // Register services (services are registered as Singletons default)
      _container.Register<INavigationService, NavigationService>();
      _container.Register<IAccountService, AccountService>();

    }

    public static T Resolve<T>() where T : class
    {
      return _container.Resolve<T>();
    }

    public static Page CreatePageFor(Type pageModelType)
    {
      var pageType = _viewLookup[pageModelType];
      var page = (Page)Activator.CreateInstance(pageType);
      var pageModel = _container.Resolve(pageModelType);
      page.BindingContext = pageModel;
      return page;
    }

    static void Register<TPageModel, TPage>() where TPageModel : PageModelBase where TPage : Page
    {
      _viewLookup.Add(typeof(TPageModel), typeof(TPage));
      _container.Register<TPageModel>();
    }
  }
}
