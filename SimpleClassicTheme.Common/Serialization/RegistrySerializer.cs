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

                var propertyValue = property.GetValue(obj);
                var value = key.GetValue(property.Name, propertyValue);

                try
                {
                    switch (propertyValue)
                    {
                        case string:
                            break;

                        case bool when value is string boolString:
                            if (bool.TryParse(boolString, out var @bool))
                            {
                                value = @bool;
                            }
                            break;

                        default:
                            if (property.PropertyType.IsClass && propertyValue != null)
                            {
                                using (var subKey = key.OpenSubKey(property.Name))
                                {
                                    if (subKey != null)
                                    {
                                        DeserializeFromRegistry(subKey, propertyValue);
                                    }
                                }

                                continue;
                            }
                            break;
                    }

                    property.SetValue(obj, value);
                }
                catch when (ignoreErrors)
                {
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