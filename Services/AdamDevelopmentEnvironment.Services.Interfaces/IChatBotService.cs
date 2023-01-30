
namespace AdamDevelopmentEnvironment.Services.Interfaces
{
    public interface IChatBotService
    {
        string GetMessage(string queryMessage);
        string GetStatus();
    }
}
