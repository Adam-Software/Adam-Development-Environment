﻿using HandyControl.Controls;
using HandyControl.Data;
using System;

namespace AdamDevelopmentEnvironment.Core.Notification
{
    public class ApplicationGrowls : IApplicationGrowls
    {
        public event GrowlsHappenedEventHandler RaiseGrowlsHappenedEvent;
        public event ClearGrowlsEventHandler RaiseClearGrowlsEvent;

        public void ErrorGrowls(string message)
        {
            GrowlInfo gf = new()
            {
                Message = message,
                StaysOpen = false,
                IsCustom = true,
                ShowCloseButton = false,
                WaitTime = 5,
                Token = "GrowlToNotifyBar",
            };

            Growl.Error(gf);

            if (NotShowClobalGrowl)
                return;

            OnRaiseGrowlsHappenedEvent();

            if (IsSilentModeEnabled)
                return;

            gf.StaysOpen = false;
            gf.Token = "GlobalGrowl";
            Growl.ErrorGlobal(gf);
        }

        public void InformationGrowls(string message)
        {
            GrowlInfo gf = new()
            {
                Message = message,
                StaysOpen = false,
                IsCustom = true,
                ShowCloseButton = true,
                WaitTime = 5,
                Token = "GrowlToNotifyBar",
            };

            Growl.Info(gf);

            if (NotShowClobalGrowl)
                return;

            OnRaiseGrowlsHappenedEvent();

            if (IsSilentModeEnabled) 
                return; 

            gf.StaysOpen = false;
            gf.Token = "GlobalGrowl";
            Growl.InfoGlobal(gf);
        }

        public void AskGrowls(string message, Func<bool, bool> actionBeforeClose)
        {
            GrowlInfo gf = new()
            {
                Message = message,
                StaysOpen = true,
                IsCustom = true,
                ShowCloseButton = true,
                CancelStr = "Отменить",
                ConfirmStr = "Подтвердить",
                Token = "GrowlToNotifyBar",
                ActionBeforeClose = actionBeforeClose,
            };

            Growl.Ask(gf);
            
            if (NotShowClobalGrowl)
                return;

            OnRaiseGrowlsHappenedEvent();

            if (IsSilentModeEnabled)
                return;

            gf.ActionBeforeClose = null;
            gf.Message = "Пришло уведомление требующее действия";
            gf.StaysOpen = false;
            gf.Token = "GlobalGrowl";
            Growl.InfoGlobal(gf);
        }

        public void ClearNotifyBarGrowls()
        {
            Growl.Clear("GrowlToNotifyBar");
            OnRaiseClearGrowlsEvent(GrowlsType.NotifyBar);
        }

        public void ClearClobalGrowls()
        {
            Growl.ClearGlobal();
            OnRaiseClearGrowlsEvent(GrowlsType.Global);
        }

        /// <summary>
        /// If true don`t show Global growl
        /// </summary>
        private bool mNotShowClobalGrowl = false;
        public bool NotShowClobalGrowl 
        { 
            get { return mNotShowClobalGrowl; }
            set 
            { 
                if(value == mNotShowClobalGrowl)
                    return;

                mNotShowClobalGrowl = value;
            } 
        }

        /// <summary>
        /// Silent mode disabled global growls
        /// </summary>
        private bool mIsSilentModeEnabled;
        public bool IsSilentModeEnabled
        {
            get { return mIsSilentModeEnabled; }
            set
            {
                if (value == mIsSilentModeEnabled)
                    return;

                mIsSilentModeEnabled = value;

            }
        }

        protected virtual void OnRaiseGrowlsHappenedEvent()
        {
            GrowlsHappenedEventHandler raiseEvent = RaiseGrowlsHappenedEvent;
            raiseEvent?.Invoke(this);
        }

        protected virtual void OnRaiseClearGrowlsEvent(GrowlsType growlsType)
        {
            ClearGrowlsEventHandler raiseEvent = RaiseClearGrowlsEvent;
            ClearGrowlsEventArgs growlsEventArgs = new()
            {
                GrowlsType = growlsType,
            };

            raiseEvent?.Invoke(this, growlsEventArgs);
        }
    }
}
