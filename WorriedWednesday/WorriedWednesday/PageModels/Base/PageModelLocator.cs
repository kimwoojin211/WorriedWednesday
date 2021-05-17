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
using WorriedWednesday.Services.UserWorry;

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
      Register<DashboardPageModel, DashboardPage>();
      Register<LoginPageModel, LoginPage>();
      Register<ReadOthersPageModel, ReadOthersPage>();
      Register<UserWorriesPageModel, UserWorriesPage>();
      Register<SettingsPageModel, SettingsPage>();
      Register<WriteWorryPageModel, WriteWorryPage>();
      //Register<ReadRepliesPageModel, ReadRepliesPage>();


      // Register services (services are registered as Singletons default)
      _container.Register<INavigationService, NavigationService>();
      _container.Register<IAccountService,MockAccountService>();
      _container.Register<IUserWorryService,MockUserWorryService> ();


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
