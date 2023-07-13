using Prism.Commands;

namespace AdamDevelopmentEnvironment.Core.Commands
{
    public interface IApplicationCommands
    {
        CompositeCommand ExpandNotifyBarCommand { get; }   
    }
}
