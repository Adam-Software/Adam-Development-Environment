namespace AdamDevelopmentEnvironment.Services.Interfaces
{
    public interface ILoggerService
    {
        void WriteWarningLog(string logMessage);
        void WriteLog(string logMessage);

        void Dispose();
    }
}
