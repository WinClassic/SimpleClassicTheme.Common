using System;

namespace SimpleClassicTheme.Common.Providers
{
    public abstract class Provider<T>
    {
        public event EventHandler<ProviderEventArgs<T>> ItemAdded;
        public event EventHandler<ProviderEventArgs<T>> ItemRemoved;

        protected void OnItemAdded(T item)
        {
            var eventArgs = new ProviderEventArgs<T>(item);
            ItemAdded?.Invoke(this, eventArgs);
        }

        protected void OnItemRemoved(T item)
        {
            var eventArgs = new ProviderEventArgs<T>(item);
            ItemRemoved?.Invoke(this, eventArgs);
        }
    }
}
