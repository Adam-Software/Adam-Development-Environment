using System;

namespace AdamDevelopmentEnvironment.Core.Notification
{
    public class ClearGrowlsEventArgs : EventArgs
    {
        public GrowlsType GrowlsType { get; set; }
    }
}
