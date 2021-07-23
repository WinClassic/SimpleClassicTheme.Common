using System;

namespace SimpleClassicTheme.Common.Configuration
{
    public enum ConfigChangedReason
    {
        /// <summary>
        /// The current application wrote to the registry.
        /// </summary>
        Registry,

        /// <summary>
        /// Another SimpleClassicTheme application broadcasted a config change.
        /// </summary>
        ExternalApplication,
    }

    public class ConfigChangedEventArgs : EventArgs
    {
        public ConfigChangedEventArgs(ConfigType type, ConfigChangedReason reason)
        {
            Type = type;
            Reason = reason;
        }

        public ConfigChangedReason Reason { get; }
        public ConfigType Type { get; }
    }
}