using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassicTheme.Common.Helpers
{
    public static class Paths
    {
        public static string QuickLaunch
        {
            get
            {
                var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                return Path.Combine(appData, "Microsoft", "Internet Explorer", "Quick Launch");
            }
        }
    }
}
