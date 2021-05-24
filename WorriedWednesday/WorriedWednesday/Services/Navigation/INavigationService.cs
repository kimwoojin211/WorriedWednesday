using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorriedWednesday.PageModels.Base;

namespace WorriedWednesday.Services.Navigation
{
  public interface INavigationService
  {
    Task NavigateToAsync<TPageModel>(object navigationData = null, bool setRoot = false)
        where TPageModel : PageModelBase;

    Task GoBackAsync();
  }
}
