namespace AdamDevelopmentEnvironment.Core.Notification
{
    public interface IApplicationGrowls
    {
        void ErrorGrowls(string message);
        void InformationGrowls(string message);
        void ClearNotifyBarGrowls();
        void ClearClobalGrowls();
        bool NotShowClobalGrowl { get; set; }
    }
}
