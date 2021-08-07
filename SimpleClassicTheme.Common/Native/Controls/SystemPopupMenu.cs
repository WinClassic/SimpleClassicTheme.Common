using SimpleClassicTheme.Common.Native.Methods;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

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

        public int Count => throw new NotImplementedException();
        public bool IsReadOnly => throw new NotImplementedException();

        public SystemPopupItem this[int index]
        {
            get => _items[index];
            set => _items[index] = value;
        }

        public void Add(SystemPopupItem item)
        {
            SystemPopupMenu subMenu = null;

            if (item is SystemPopupMenuItem menuItem)
            {
                subMenu = menuItem.SubMenu;
            }

            PInvoke.AppendMenu(
                _hMenu,
                item.NativeFlags,
                (nuint)(subMenu?._hMenu.Value ?? (IntPtr)item.Id).ToInt32(),
                item.NativeHandle);

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
            var hWnd = (HWND)owner.Handle;
            var flags = TRACK_POPUP_MENU_FLAGS.TPM_RETURNCMD;
            int id;

            unsafe
            {
                id = User32.TrackPopupMenuEx(
                    _hMenu,
                    flags,
                    x,
                    y,
                    hWnd,
                    IntPtr.Zero);
            }

            // If the user cancels the menu without making a selection,
            // or if an error occurs, the return value is zero.
            if (id == 0)
            {
                return;
            }

            var item = SearchForId(this, id);
            if (item is SystemPopupMenuItem menuItem)
            {
                menuItem.OnClick();
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