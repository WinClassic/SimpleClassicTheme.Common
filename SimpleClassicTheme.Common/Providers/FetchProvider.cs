using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleClassicTheme.Common.Providers
{
    public abstract class FetchProvider<T> : Provider<T>, IDisposable
    {
        private bool _disposedValue;
        private T[] _oldItems;

        public void Update()
        {
            var newItems = Fetch();

            if (_oldItems == null)
            {
                foreach (var item in newItems)
                {
                    OnItemAdded(item);
                }
            }
            else
            {
                foreach (var newItem in newItems)
                {
                    var hasItem = _oldItems.Any(oldItem => EqualityPredicate(oldItem, newItem));

                    if (!hasItem)
                    {
                        OnItemAdded(newItem);
                    }
                }

                foreach (var oldItem in _oldItems)
                {
                    var hasItem = newItems.Any(newItem => EqualityPredicate(oldItem, newItem));

                    if (!hasItem)
                    {
                        OnItemRemoved(oldItem);
                    }
                }
            }

            _oldItems = newItems.ToArray();
        }

        protected virtual bool EqualityPredicate(T oldItem, T newItem)
        {
            return oldItem.Equals(newItem);
        }

        protected abstract IEnumerable<T> Fetch();

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _oldItems = null;
                }
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
