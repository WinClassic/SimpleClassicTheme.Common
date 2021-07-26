using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

namespace SimpleClassicTheme.Common.Native.Controls
{
    public abstract class SystemPopupItem
    {
        public int Id { get; set; }
        abstract internal MENU_ITEM_FLAGS NativeFlags { get; }
        abstract internal PCWSTR NativeHandle { get; }
    }
}