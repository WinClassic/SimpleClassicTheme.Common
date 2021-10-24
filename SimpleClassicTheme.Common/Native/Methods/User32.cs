using System;
using System.Runtime.InteropServices;

namespace SimpleClassicTheme.Common.Native.Methods
{
    internal class User32
    {
        [DllImport(nameof(User32))]
        internal static extern int TrackPopupMenuEx(IntPtr hmenu, uint fuFlags, int x, int y, IntPtr hwnd, IntPtr lptpm);
    }
}