using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

using static SimpleClassicTheme.Common.Native.Methods.User32;

namespace SimpleClassicTheme.Common.Native.Controls
{
    public class SystemPopupMenu : IDisposable, IList<SystemPopupItem>
    {
        private readonly HMENU _hMenu;
        private List<SystemPopupItem> _items;
        private bool _disposed;

        public SystemPopupMenu()
        {
            _hMenu = PInvoke.CreatePopupMenu();
            _items = new();
        }

        ~SystemPopupMenu()
        {
            Dispose(disposing: false);
        }

        public int Count => _items.Count;
        public bool IsReadOnly => false;

        public SystemPopupItem this[int index]
        {
            get => _items[index];
            set => _items[index] = value;
        }

        public void Add(SystemPopupItem item)
        {
            if (!item.Visible)
            {
                return;
            }

            if (!item.Id.HasValue)
            {
                item.Id = NextId;
            }

            bool result = PInvoke.AppendMenu(
                _hMenu,
                item.NativeFlags,
                (nuint)item.Id,
                item.NativeHandle);

            if (!result)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            _items.Add(item);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(SystemPopupItem item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(SystemPopupItem[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<SystemPopupItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public int IndexOf(SystemPopupItem item)
        {
            return _items.IndexOf(item);
        }

        public void Insert(int index, SystemPopupItem item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(SystemPopupItem item)
        {
            RemoveAt(IndexOf(item));
            return true;
        }

        public void RemoveAt(int index)
        {
            PInvoke.DeleteMenu(_hMenu, (uint)index, MENU_ITEM_FLAGS.MF_BYPOSITION);
            _items.RemoveAt(index);
        }

        public void Show(IWin32Window owner, int x, int y)
        {
            TRACK_POPUP_MENU_FLAGS flags =
                TRACK_POPUP_MENU_FLAGS.TPM_RETURNCMD |
                TRACK_POPUP_MENU_FLAGS.TPM_NONOTIFY;
            
            int id;

            unsafe
            {
                id = TrackPopupMenuEx(
                    _hMenu,
                    (uint)flags,
                    x,
                    y,
                    owner.Handle,
                    IntPtr.Zero);
            }

            // If the user cancels the menu without making a selection,
            // or if an error occurs, the return value is zero.
            if (id == 0)
            {
                var errorCode = Marshal.GetLastWin32Error();
                return;
            }

            var item = SearchForId(this, id);
            if (item is SystemPopupMenuItem menuItem)
            {
                menuItem.OnClick();
            }
        }

        public int NextId
        {
            get
            {
                int itemCount = Count;

                foreach (var item in this)
                {
                    if (item is SystemPopupMenuItem menuItem && menuItem.SubMenu is SystemPopupMenu subMenu)
                    {
                        itemCount += subMenu.NextId;
                    }
                }

                return itemCount;
            }
        }

        private static SystemPopupItem SearchForId(IEnumerable<SystemPopupItem> items, int itemId)
        {
            foreach (var item in items)
            {
                if (item is not SystemPopupMenuItem menuItem)
                {
                    continue;
                }

                if (menuItem.Id == itemId)
                {
                    return item;
                }
                else if (menuItem.SubMenu != null)
                {
                    var foundItems = SearchForId(menuItem.SubMenu, itemId);
                    if (foundItems != null)
                        return foundItems;
                }
            }

            return null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _items = null;
                }

                PInvoke.DestroyMenu(_hMenu);
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}