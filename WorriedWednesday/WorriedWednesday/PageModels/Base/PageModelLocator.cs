using System;
using System.Collections.Generic;
using System.Text;
using TinyIoC;
using Xamarin.Forms;

namespace WorriedWednesday.Base
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



      // Register services (services are registered as Singletons default)
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
  }
}
