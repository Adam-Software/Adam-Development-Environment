﻿
using Prism.Commands;

namespace AdamDevelopmentEnvironment.Core.Commands
{
    public class ApplicationCommands : IApplicationCommands
    {
        private readonly CompositeCommand mExpandNotifyBarCommand = new();
        public CompositeCommand ExpandNotifyBarCommand  
        {
            get { return mExpandNotifyBarCommand; }
        }
    }
}
