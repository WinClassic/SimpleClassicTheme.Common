using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

namespace SimpleClassicTheme.Common.Native.Controls
{
    public class SystemPopupMenuSeparator : SystemPopupItem
    {
        internal override MENU_ITEM_FLAGS NativeFlags => MENU_ITEM_FLAGS.MF_SEPARATOR;

        internal override PCWSTR NativeHandle => null;
    }
}