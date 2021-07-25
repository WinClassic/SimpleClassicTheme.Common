using System;

namespace SimpleClassicTheme.Common.Configuration
{
    public class ConfigChangedEventArgs : EventArgs
    {
        public ConfigChangedEventArgs(ConfigType type)
        {
            Type = type;
        }

        public ConfigType Type { get; }
    }
}