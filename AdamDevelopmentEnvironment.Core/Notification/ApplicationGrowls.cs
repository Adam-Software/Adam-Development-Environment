using HandyControl.Controls;
using HandyControl.Data;

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
                StaysOpen = true,
                IsCustom = true,
                ShowCloseButton = false,
                WaitTime = 3,
                Token = "GrowlToNotifyBar",
            };

            Growl.Error(gf);

            if (NotShowClobalGrowl)
                return;

            gf.StaysOpen = false;
            gf.Token = "GlobalGrowl";
            Growl.ErrorGlobal(gf);

            OnRaiseGrowlsHappenedEvent();
        }

        public void InformationGrowls(string message)
        {
            GrowlInfo gf = new()
            {
                Message = message,
                StaysOpen = true,
                IsCustom = true,
                ShowCloseButton = false,
                WaitTime = 3,
                Token = "GrowlToNotifyBar",
            };

            Growl.Info(gf);

            if (NotShowClobalGrowl)
                return;

            gf.StaysOpen = false;
            gf.Token = "GlobalGrowl";
            Growl.InfoGlobal(gf);

            OnRaiseGrowlsHappenedEvent();
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
