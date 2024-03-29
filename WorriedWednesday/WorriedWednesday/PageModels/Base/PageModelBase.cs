﻿using System.Threading.Tasks;

namespace WorriedWednesday.PageModels.Base
{
  public class PageModelBase : ExtendedBindableObject
  {
    string _title;
    bool _isLoading;

    public string Title
    {
      get => _title;
      set => SetProperty(ref _title, value);
    }

    public bool IsLoading
    {
      get => _isLoading;
      set => SetProperty(ref _isLoading, value);
    }

    public virtual Task InitializeAsync(object navigationData = null)
    {
      return Task.CompletedTask;
    }

  }
}
