#nullable enable

using System.Reflection;
using System.Windows.Forms;

namespace SimpleClassicTheme.Common.Helpers
{
    public class HelperMethods
    {
        public static string? GetApplicationVersion()
        {
            string? version = Application.ProductVersion.ToString();
            return version;
        }
    }
}
