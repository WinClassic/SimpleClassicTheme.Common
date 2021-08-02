using Microsoft.Win32;

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

namespace SimpleClassicTheme.Common.Configuration
{
    public enum ConfigType
    {
        Global = 0,

        /// <summary>
        /// Config of SimpleClassicTheme
        /// </summary>
        Base = 1,

        /// <summary>
        /// Config of SimpleClassicThemeTaskbar
        /// </summary>
        Taskbar = 2,

        /// <summary>
        /// Config of SimpleClassicThemeExplorer
        /// </summary>
        Explorer = 3,

        /// <summary>
        /// Config of SimpleClassicThemeControlPanel
        /// </summary>
        ControlPanel = 4,
    }

    /// <summary>
    /// Provides a base class for creating config classes.
    /// </summary>
    /// <typeparam name="T">The class that is using <see cref="ConfigBase{T}"/>.</typeparam>
    public abstract class ConfigBase<T> where T : ConfigBase<T>, new()
    {
        private static readonly object s_lock = new();
        private static T s_default;
        private readonly RegistryKey _registryKey;
        private ConfigMessageFilter _messageFilter;

        public ConfigBase(string registryPath, ConfigType type)
        {
            Type = type;
            _registryKey = Registry.CurrentUser.CreateSubKey(@"Software\1337ftw\" + registryPath);
            ReadFromRegistry();
            SubscribeToConfigChanges();
        }

        public event EventHandler<ConfigChangedEventArgs> Changed;

        /// <summary>
        /// Singleton instance. Use this property to get a shared instance of this config class.
        /// </summary>
        public static T Default
        {
            get
            {
                lock (s_lock)
                {
                    // We can't enforce a singleton pattern here
                    // because the new() constraint forces us to
                    // always have a public constructor

                    if (s_default == null)
                        s_default = new T();

                    return s_default;
                }
            }
        }

        public ConfigType Type { get; }

        /// <summary>
        /// Reads all values from the registry key and applies it to this object.
        /// </summary>
        /// <param name="registryPath">The registry path where the config data will be stored to. Always prefixed with "HKCU\Software\1337ftw".</param>
        public void ReadFromRegistry(bool ignoreErrors = false)
        {
            RegistrySerializer.DeserializeFromRegistry<T>(_registryKey, this as T, ignoreErrors);
        }

        public void WriteToRegistry()
        {
            RegistrySerializer.SerializeToRegistry<T>(_registryKey, this as T);
            BroadcastConfigChange();
        }

        private void BroadcastConfigChange()
        {
            var wParam = (WPARAM)(UIntPtr)Type;
            var lpInfo = BROADCAST_SYSTEM_MESSAGE_INFO.BSM_APPLICATIONS;
            int result;

            unsafe
            {
                result = PInvoke.BroadcastSystemMessage(
                    BROADCAST_SYSTEM_MESSAGE_FLAGS.BSF_FORCEIFHUNG | BROADCAST_SYSTEM_MESSAGE_FLAGS.BSF_POSTMESSAGE,
                    &lpInfo,
                    _messageFilter.WindowMessage,
                    wParam,
                    IntPtr.Zero);
            }

            if (result == -1)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        private void SubscribeToConfigChanges()
        {
            Application.AddMessageFilter(_messageFilter = new(this));
        }

        private class ConfigMessageFilter : IMessageFilter
        {
            private const string _windowMessageKey = "SCT_CONFIGCHANGED";
            private readonly ConfigBase<T> _config;

            public ConfigMessageFilter(ConfigBase<T> config)
            {
                _config = config ?? throw new ArgumentNullException(nameof(config));

                var result = PInvoke.RegisterWindowMessage(_windowMessageKey);

                if (result == 0x00)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                else
                {
                    WindowMessage = result;
                }
            }

            /// <summary>
            /// The registered window message with which you can receive config changes.
            /// </summary>
            public uint WindowMessage { get; }

            public bool PreFilterMessage(ref Message m)
            {
                if ((uint)m.Msg == WindowMessage)
                {
                    var configType = (ConfigType)(int)m.WParam;

                    if (_config.Type == configType)
                    {
                        var eventArgs = new ConfigChangedEventArgs(
                            configType);

                        _config.Changed?.Invoke(_config, eventArgs);

                        return true;
                    }
                }

                return false;
            }
        }
    }
}