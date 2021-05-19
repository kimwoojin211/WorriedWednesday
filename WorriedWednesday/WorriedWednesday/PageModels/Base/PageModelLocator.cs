using System;
using System.Collections.Generic;
using TinyIoC;
using WorriedWednesday.Services.Navigation;
using WorriedWednesday.Pages;
using WorriedWednesday.Services.Account;
using WorriedWednesday.Services.AllWorries;
using WorriedWednesday.Services;
using WorriedWednesday.Models;
using Xamarin.Forms;

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
      Register<SettingsPageModel, SettingsPage>();
      Register<WriteMessagePageModel, WriteMessagePage>();
      Register<UserWorriesPageModel, UserWorriesPage>();
      Register<WorryDetailsPageModel, WorryDetailsPage>();


      // Register services (services are registered as Singletons default)

      _container.Register<INavigationService, NavigationService>();

      // mock/test services

      //_container.Register<IAccountService, MockAccountService>();
      _container.Register<IAllWorriesService, MockAllWorriesService>();
       _container.Register(DependencyService.Get<IRepository<TestData>>());

      //firestore services

      _container.Register<IAccountService>(DependencyService.Get<IAccountService>());
      //_container.Register<IAllWorriesService>(DependencyService.Get<IAllWorriesService>());

    }

    /// <summary>
    /// Private utility method to Register page and page model for page retrieval by it's
    /// specified page model type.
    /// </summary>
    /// <typeparam name="TPageModel"></typeparam>
    /// <typeparam name="TPage"></typeparam>
    static void Register<TPageModel, TPage>() where TPageModel : PageModelBase where TPage : Page
    {
      _viewLookup.Add(typeof(TPageModel), typeof(TPage));
      _container.Register<TPageModel>();
    }
    public static T Resolve<T>() where T : class 
    {
      try
      {
        return _container.Resolve<T>();
      }
      catch (TinyIoCResolutionException e)
      {
        var message = e.Message;
        System.Diagnostics.Debug.WriteLine(e.Message);

        while (e.InnerException is TinyIoCResolutionException ex)
        {
          message = ex.Message;
          System.Diagnostics.Debug.WriteLine("\t" + ex.Message);
          e = ex;
        }

        #if DEBUG
        App.Current.MainPage.DisplayAlert("Resolution Error", message, "Ok");
        #endif

      }
      return default(T);
    }



    public static Page CreatePageFor<TPageModelType>() where TPageModelType : PageModelBase
    {
      Type pageModelType = typeof(TPageModelType);
      var pageType = _viewLookup[pageModelType];
      var page = (Page)Activator.CreateInstance(pageType);
      var pageModel = Resolve<TPageModelType>();
      page.BindingContext = pageModel;
      return page;
    }
  }
}