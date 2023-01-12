using AdamDevelopmentEnvironment.Services.Interfaces;

namespace AdamDevelopmentEnvironment.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
