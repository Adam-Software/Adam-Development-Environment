﻿namespace AdamDevelopmentEnvironment.Core.Notification
{
    public delegate void GrowlsHappenedEventHandler(object sender);
    public delegate void ClearGrowlsEventHandler(object sender, ClearGrowlsEventArgs e);
    public interface IApplicationGrowls
    {
        public event GrowlsHappenedEventHandler RaiseGrowlsHappenedEvent;
        public event ClearGrowlsEventHandler RaiseClearGrowlsEvent;

        void ErrorGrowls(string message);
        void InformationGrowls(string message);
        void ClearNotifyBarGrowls();
        void ClearClobalGrowls();
        bool NotShowClobalGrowl { get; set; }
    }
}
