
namespace AdamDevelopmentEnvironment.Services.Interfaces
{
    public interface IChatBotService
    {
        void LoginUserIfNeeded();
        string GetMessage(string queryMessage);
        string GetStatus();
    }
}
