#nullable enable

using System.Reflection;

namespace SimpleClassicTheme.Common.Helpers
{
    public class HelperMethods
    {
        public static string? GetApplicationVersion()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var versionAttribute = assembly.GetCustomAttribute<AssemblyVersionAttribute>();

            return versionAttribute?.Version;
        }
    }
}
