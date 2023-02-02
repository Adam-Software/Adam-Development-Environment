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

        static string Config(string what)
        {
            return what switch
            {
                "server_address" => "149.154.167.40:443",
                "test" => "true",
                "api_id" => "",
                "api_hash" => "",
                //case "phone_number": return "+9996614567";
                //case "verification_code": return "11111";
                _ => null,// let WTelegramClient decide the default config
            };
        }

        public async void LoginUserIfNeeded(string phoneNumber)
        {
            using var client = new WTelegram.Client(Config, null);
            
            _ = await client.LoginUserIfNeeded();
            _ = await client.Login(phoneNumber);
        }
    }
}
