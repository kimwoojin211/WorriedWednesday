using System.Threading.Tasks;
using WorriedWednesday.PageModels.Base;

namespace WorriedWednesday.PageModels
{
  public class DashboardPageModel : PageModelBase
  {
    ReadOthersPageModel _readOthersPM;
    UserWorriesPageModel _userWorriesPM;
    SettingsPageModel _settingsPM;


    public ReadOthersPageModel ReadOthersPageModel
    {
      get => _readOthersPM;
      set => SetProperty(ref _readOthersPM, value);
    }
    public UserWorriesPageModel UserWorriesPageModel
    {
      get => _userWorriesPM;
      set => SetProperty(ref _userWorriesPM, value);
    }
    public SettingsPageModel SettingsPageModel
    {
      get => _settingsPM;
      set => SetProperty(ref _settingsPM, value);
    }

    public DashboardPageModel(ReadOthersPageModel readOthersPM, 
                              UserWorriesPageModel userWorriesPM, 
                              SettingsPageModel settingsPM)
    {
      ReadOthersPageModel = readOthersPM;
      UserWorriesPageModel = userWorriesPM;
      SettingsPageModel = settingsPM;
    }
    public override Task InitializeAsync(object navigationData)
    {
      return Task.WhenAny(base.InitializeAsync(navigationData),
                          ReadOthersPageModel.InitializeAsync(null),
                          UserWorriesPageModel.InitializeAsync(null),
                          SettingsPageModel.InitializeAsync(null));
    }
  }
}
