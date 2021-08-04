using System;

namespace SimpleClassicTheme.Common.Serialization
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, Inherited = true)]
    public sealed class RegistryIgnoreAttribute : Attribute
    {
        public RegistryIgnoreAttribute()
        {
        }
    }
}
