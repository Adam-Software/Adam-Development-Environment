namespace AdamDevelopmentEnvironment.Services.Interfaces
{
    public interface ILoggerService
    {

        //0
        void WriteVerboseLog(string logMessage);

        //1
        void WriteDebugLog(string logMessage);

        //2
        void WriteInformationLog(string logMessage);

        //3
        void WriteWarningLog(string logMessage);

        //4
        void WriteErrorLog(string logMessage);

        //5
        void WriteFatalLog(string logMessage);

        void Dispose();
    }
}
