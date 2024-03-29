﻿using AdamDevelopmentEnvironment.Services.Interfaces;
using Prism.Regions;
using System;

namespace AdamDevelopmentEnvironment.Core.Mvvm
{
    public class RegionViewModelBase : ViewModelBase, INavigationAware, IConfirmNavigationRequest
    {
        protected IRegionManager RegionManager { get; private set; }
        protected ILoggerService LoggerService { get; private set; }

        public RegionViewModelBase(IRegionManager regionManager, ILoggerService loggerService)
        {
            RegionManager = regionManager;
            LoggerService = loggerService;
        }

        #region Navigation

        public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(true);
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }

        #endregion
    }
}
