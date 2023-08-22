using AdamDevelopmentEnvironment.Services.Interfaces.ITcpClientDependency;
using System;
using System.Threading.Tasks;

namespace AdamDevelopmentEnvironment.Services.Interfaces
{
    public delegate void ClientConnectedEventHandler(object sender, ConnectionEventArgs e);
    public delegate void ClientDisconnectedEventHandler(object sender, ConnectionEventArgs e);

    /// <summary>
    /// A simple client for implementing outdated connection control functionality and supporting 
    /// older server (aka robot) versions
    /// The architecture does not imply sending messages through this channel.
    /// </summary>
    public interface ITcpClientService : IDisposable
    {
        public event ClientConnectedEventHandler RaiseClientConnectedEvent;
        public event ClientDisconnectedEventHandler RaiseClientDisconnectedEvent;
        public Task ReconnectAsync();
        public Task ConnectAsync();
        public Task DisconnectAsync();
        public bool IsConnected { get; }
    }
}
