using System;
using System.Runtime.InteropServices;

using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

namespace SimpleClassicTheme.Common.Native.Methods
{
    internal class User32
    {
        [DllImport(nameof(User32))]
        internal static extern int TrackPopupMenuEx(HMENU hmenu, TRACK_POPUP_MENU_FLAGS fuFlags, int x, int y, HWND hwnd, IntPtr lptpm);
    }
}