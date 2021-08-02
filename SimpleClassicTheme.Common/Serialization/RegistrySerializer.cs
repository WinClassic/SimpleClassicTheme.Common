using Microsoft.Win32;

using System;
using System.Reflection;

namespace SimpleClassicTheme.Common
{
    /// <summary>
    /// Provides a serializer that writes and reads values from the registry and applies them from or to objects.
    /// </summary>
    public static class RegistrySerializer
    {
        private const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance;

        public static void DeserializeFromRegistry<T>(RegistryKey key, T obj, bool ignoreErrors = true)
        {
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var properties = typeof(T).GetProperties(bindingFlags);
            foreach (var property in properties)
            {
                if (!property.CanWrite)
                {
                    continue;
                }

                if (property.PropertyType.IsClass)
                {
                    using (var subKey = key.OpenSubKey(property.Name))
                    {
                        if (subKey != null)
                        {
                            DeserializeFromRegistry(subKey, property.GetValue(obj));
                        }
                    }
                    continue;
                }

                object value = property.GetValue(obj);
                var registryValue = key.GetValue(property.Name, value);

                // string → bool
                if (registryValue is string boolString && property.PropertyType == typeof(bool))
                {
                    registryValue = bool.Parse(boolString);
                }

                try
                {
                    property.SetValue(obj, registryValue);
                }
                catch
                {
                    if (!ignoreErrors)
                    {
                        throw;
                    }
                }
            }
        }

        public static void SerializeToRegistry<T>(RegistryKey key, T obj)
        {
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var properties = typeof(T).GetProperties(bindingFlags);
            foreach (var property in properties)
            {
                if (!property.CanWrite)
                {
                    continue;
                }

                RegistryValueKind valueKind = RegistryValueKind.Unknown;
                object value = property.GetValue(obj);
                switch (value)
                {
                    case bool boolValue:
                        value = boolValue.ToString();
                        valueKind = RegistryValueKind.String;
                        break;

                    case int:
                    case Enum:
                        valueKind = RegistryValueKind.DWord;
                        break;

                    case string:
                        valueKind = RegistryValueKind.String;
                        break;

                    default:
                        if (property.PropertyType.IsClass)
                        {
                            using (var subKey = key.CreateSubKey(property.Name))
                            {
                                SerializeToRegistry(subKey, property.GetValue(obj));
                            }
                            continue;
                        }
                        else
                        {
                            // Logger.Log(LoggerVerbosity.Basic, "RegistrySerializer", $"Ignoring property {property.Name} because {value?.GetType()} is an unknown type");
                        }

                        continue;
                }

                key.SetValue(property.Name, value, valueKind);
            }
        }
    }
}