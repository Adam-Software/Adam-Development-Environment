using System;
using System.Threading.Tasks;

namespace AdamDevelopmentEnvironment.Services.Interfaces
{
    /// <summary>
    /// A simple client for implementing outdated connection control functionality and supporting 
    /// older server (aka robot) versions
    /// The architecture does not imply sending messages through this channel.
    /// </summary>
    public interface ITcpClientService : IDisposable
    {
        event EventHandler ClientConnected;

        event EventHandler ClientDisconnected;

        Task ReconnectAsync();
        Task ConnectAsync();
        Task DisconnectAsync();
    }
}
