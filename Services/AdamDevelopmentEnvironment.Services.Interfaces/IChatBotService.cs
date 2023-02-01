
namespace AdamDevelopmentEnvironment.Services.Interfaces
{
    public interface IChatBotService
    {
        void LoginUserIfNeeded(string phoneNumber);
        string GetMessage(string queryMessage);
        string GetStatus();
    }
}
