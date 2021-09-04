using System;

namespace SimpleClassicTheme.Common.Providers
{
    public class ProviderEventArgs<T>
    {
        public T Item { get; }

        public ProviderEventArgs(T item)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item));
        }
    }
}
