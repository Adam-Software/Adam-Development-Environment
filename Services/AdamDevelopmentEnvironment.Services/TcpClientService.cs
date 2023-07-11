using AdamDevelopmentEnvironment.Services.Interfaces;
using SuperSimpleTcp;
using System;
using System.Threading.Tasks;

namespace AdamDevelopmentEnvironment.Services
{
    public class TcpClientService : ITcpClientService
    {
        public event EventHandler ClientConnected;
        public event EventHandler ClientDisconnected;
        
        private ILoggerService LoggerService { get; set; }
        private SimpleTcpClient mTcpClient;

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
            LoggerService.WriteInformationLog($"Client {e.IpPort} connected");
            ClientConnected?.Invoke(this, e);
        }

        private void EventsDisconnected(object sender, ConnectionEventArgs e)
        {
            LoggerService.WriteVerboseLog($"Client {e.IpPort} disconnected. Reason: {e.Reason}");
            ClientDisconnected?.Invoke(this, e);
        }

        #endregion

        public Task ConnectAsync()
        {
            Task task;

            LoggerService.WriteVerboseLog("Called tcp client ConnectAsync()");

            try
            {
                mTcpClient.Connect();
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

            if (mTcpClient.IsConnected)
                task = DisconnectAsync();

            if (!mTcpClient.IsConnected)
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
    }
}
