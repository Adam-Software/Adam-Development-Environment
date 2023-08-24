using AdamDevelopmentEnvironment.Services.Interfaces;
using SuperSimpleTcp;
using System;
using System.Threading.Tasks;
using ServiceConnectionEventArgs = AdamDevelopmentEnvironment.Services.Interfaces.ITcpClientDependency.ConnectionEventArgs;

namespace AdamDevelopmentEnvironment.Services
{
    public class TcpClientService : ITcpClientService
    {
        public event ClientConnectedEventHandler RaiseClientConnectedEvent;
        public event ClientDisconnectedEventHandler RaiseClientDisconnectedEvent;
        
        private ILoggerService LoggerService { get; set; }
        private readonly SimpleTcpClient mTcpClient;

        public TcpClientService(ILoggerService loggerService) 
        {
            LoggerService = loggerService;
            mTcpClient = new SimpleTcpClient("10.254.254.230:15000");
            
            mTcpClient.Events.Connected += EventsConnected;
            mTcpClient.Events.Disconnected += EventsDisconnected;

            LoggerService.WriteInformationLog("Init tcp client complete");
        }

        #region events

        private void EventsConnected(object sender, ConnectionEventArgs e)
        {
            IsConnected = true;
            LoggerService.WriteInformationLog($"Client {e.IpPort} connected");
            OnRaiseClientConnectedEvent(e);
        }

        private void EventsDisconnected(object sender, ConnectionEventArgs e)
        {
            IsConnected = false;
            LoggerService.WriteVerboseLog($"Client {e.IpPort} disconnected. Reason: {e.Reason}");
            OnRaiseClientDisconnectedEvent(e);
        }

        #endregion

        public bool IsConnected { get; private set; }

        public Task ConnectAsync()
        {
            Task task;

            LoggerService.WriteVerboseLog("Called tcp client ConnectAsync()");

            try
            {
                mTcpClient.ConnectWithRetries(5000);
                task = Task.CompletedTask;
            }
            catch (Exception ex)
            {
                LoggerService.WriteErrorLog($"Called tcp client ConnectAsync() but throw exception: {ex.Message}");
                task = Task.CompletedTask;
            }

            return task;
        }

        
        public Task DisconnectAsync()
        {
            Task task;

            LoggerService.WriteVerboseLog("Called tcp client DisconnectAsync()");

            try
            {
                task = mTcpClient.DisconnectAsync();
            }
            catch (Exception ex)
            {
                LoggerService.WriteErrorLog($"Called tcp server DisconnectAsync() but throw exception {ex.Message}");
                task = Task.CompletedTask;
            }

            return task;
        }

        public Task ReconnectAsync()
        {
            Task task = Task.CompletedTask;

            if (IsConnected)
                task = DisconnectAsync();

            if (IsConnected)
                task = ConnectAsync();

            return task;
        }

        public void Dispose()
        {
            mTcpClient.Events.Connected -= EventsConnected;
            mTcpClient.Events.Disconnected -= EventsDisconnected;

            mTcpClient.Disconnect();
            mTcpClient.Dispose();
        }

        protected virtual void OnRaiseClientConnectedEvent(ConnectionEventArgs e)
        {
            ClientConnectedEventHandler raiseEvent = RaiseClientConnectedEvent;

            ServiceConnectionEventArgs eventArgs = new ServiceConnectionEventArgs
            {
                IpPort = e.IpPort,
                Reason = e.Reason.ToString()
            };
            
            raiseEvent?.Invoke(this, eventArgs);
        }

        protected virtual void OnRaiseClientDisconnectedEvent(ConnectionEventArgs e)
        {
            ClientDisconnectedEventHandler raiseEvent = RaiseClientDisconnectedEvent;
            
            ServiceConnectionEventArgs eventArgs = new ServiceConnectionEventArgs
            {
                IpPort = e.IpPort,
                Reason = e.Reason.ToString()
            };

            raiseEvent?.Invoke(this, eventArgs);
        }
    }
}
