using AdamDevelopmentEnvironment.Services.Interfaces;

namespace AdamDevelopmentEnvironment.Services
{
    public class ChatBotService : IChatBotService
    {
        public string GetMessage(string queryMessage)
        {
            throw new System.NotImplementedException();
        }

        public string GetStatus()
        {
            throw new System.NotImplementedException();
        }

        public async void LoginUserIfNeeded(string phoneNumber)
        {
            using var client = new WTelegram.Client(,);
            _ = await client.LoginUserIfNeeded();
            _ = await client.Login(phoneNumber);
        }
    }
}
