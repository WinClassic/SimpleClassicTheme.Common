﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimpleClassicTheme.Common.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SimpleClassicTheme.Common.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap CrashIcon {
            get {
                object obj = ResourceManager.GetObject("CrashIcon", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} exited due to an error. If you like to help us fix it, click on Send to submit an error report over Sentry. To learn more about the data collected click here..
        /// </summary>
        internal static string ErrorForm_Crash_Description {
            get {
                return ResourceManager.GetString("ErrorForm_Crash_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        internal static string ErrorForm_Crash_DescriptionLink {
            get {
                return ResourceManager.GetString("ErrorForm_Crash_DescriptionLink", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to It seems like {0} has crashed..
        /// </summary>
        internal static string ErrorForm_Crash_Header {
            get {
                return ResourceManager.GetString("ErrorForm_Crash_Header", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} crashed.
        /// </summary>
        internal static string ErrorForm_Crash_Title {
            get {
                return ResourceManager.GetString("ErrorForm_Crash_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The currently known data collected by error reports sent in debug builds is:
        ///
        ///• Current application log
        ///    • OS version
        ///    • SCT and application version
        ///    • Depending on the problem, this might also include information about open windows
        ///
        ///• Stack trace (information about where the program crashed)
        ///
        ///• System Environment
        ///    • OS version (e.g. Microsoft Windows 10.0.22000)
        ///    • .NET runtime version
        ///    • SCT application version
        ///    • Sentry SDK version (SDK version of the error reporting lib [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ErrorForm_DataCollection {
            get {
                return ResourceManager.GetString("ErrorForm_DataCollection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} encountered an internal error. If you like to help us fix it, click on Send to submit an error report over Sentry. To learn more about the data collected click here..
        /// </summary>
        internal static string ErrorForm_Problem_Description {
            get {
                return ResourceManager.GetString("ErrorForm_Problem_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .
        /// </summary>
        internal static string ErrorForm_Problem_DescriptionLink {
            get {
                return ResourceManager.GetString("ErrorForm_Problem_DescriptionLink", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to It seems like {0} had an internal error..
        /// </summary>
        internal static string ErrorForm_Problem_Header {
            get {
                return ResourceManager.GetString("ErrorForm_Problem_Header", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} encountered an internal error.
        /// </summary>
        internal static string ErrorForm_Problem_Title {
            get {
                return ResourceManager.GetString("ErrorForm_Problem_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ProblemIcon {
            get {
                object obj = ResourceManager.GetObject("ProblemIcon", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
