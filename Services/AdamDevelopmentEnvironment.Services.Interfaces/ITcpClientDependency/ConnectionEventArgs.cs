using System;

namespace AdamDevelopmentEnvironment.Services.Interfaces.ITcpClientDependency
{
    public class ConnectionEventArgs : EventArgs
    {
        public string IpPort { get; set; }

        public string Reason { get; set;  } = "None";
    }
}
