using Sentry;

using SimpleClassicTheme.Common.Configuration;
using SimpleClassicTheme.Common.ErrorHandling.Forms;
using SimpleClassicTheme.Common.Helpers;
using SimpleClassicTheme.Common.Logging;

using System;
using System.Diagnostics;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SimpleClassicTheme.Common.ErrorHandling
{
    public enum ExceptionSeverity
    {
        /// <summary>
        /// Exceptions that would cause the application to exit.
        /// </summary>
        Fatal,

        /// <summary>
        /// Exceptions that occured within the application but didn't cause it to crash.
        /// </summary>
        Unhandled,

        /// <summary>
        /// Exceptions that are supressed inside a try-catch block
        /// </summary>
        Handled,
    }

    public class ErrorHandler : IDisposable
    {
        private IDisposable _sentry = null;

        public string SentryDsn { get; set; }

        public string SentryProjectName { get; set; }

        public bool IsSentryAvailable => _sentry is not null;

        public static void ShowErrorCollectionDetails()
        {
            const string url = "https://github.com/WinClassic/SimpleClassicTheme.Common/wiki/Sentry-integration";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        /// <summary>
        /// Initializes the Sentry SDK, opens optionally a consent dialog as well when the user has not consented yet.
        /// </summary>
        public void InitializeSentry()
        {
            if (string.IsNullOrWhiteSpace(SentryDsn))
            {
                return;
            }

            if (GlobalConfig.Default.EnableSentry == SentryConsent.Ask)
            {
                using (var consentForm = new ConsentForm())
                {
                    consentForm.ShowDialog();
                }
            }

            if (IsSentryAvailable)
            {
                return;
            }

            if (GlobalConfig.Default.EnableSentry == SentryConsent.Accepted)
            {
                _sentry = SentrySdk.Init(o =>
                {
                    o.Dsn = SentryDsn;
                    o.MaxBreadcrumbs = 50;
                    o.StackTraceMode = StackTraceMode.Enhanced;
                    o.AutoSessionTracking = GlobalConfig.Default.EnableSessionTracking;
                    
                    if (!string.IsNullOrWhiteSpace(SentryProjectName) &&
                        HelperMethods.GetApplicationVersion() is string appVersion)
                    {
                        o.Release = $"{SentryProjectName}@{appVersion}";
                    }
#if DEBUG
                    o.Debug = true;
#endif
                });
            }
        }

        public void SubscribeToErrorEvents()
        {
            Application.ThreadException += (sender, e) =>
            {
                HandleException(new ErrorDetails
                {
                    Exception = e.Exception,
                    Fatal = false,
                    Handler = this,
                });
            };

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                if (e.ExceptionObject is not Exception ex)
                {
                    return;
                }

                HandleException(new ErrorDetails
                {
                    Exception = ex,
                    Fatal = e.IsTerminating,
                    Handler = this,
                });
            };
        }

        internal void SubmitError(ErrorDetails details, bool submitLog)
        {
            if (!IsSentryAvailable)
            {
                return;
            }

            SentrySdk.ConfigureScope(scope =>
            {
                scope.Level = details.Fatal
                    ? SentryLevel.Fatal
                    : SentryLevel.Error;

                if (submitLog)
                {
                    scope.AddAttachment(Logger.Instance.FilePath, AttachmentType.Default);
                }

                SentrySdk.CaptureException(details.Exception);
            });
        }

        /// <summary>
        /// Handles an exception and takes appropiate action.
        /// </summary>
        /// <param name="fatal"><c>true</c> if the exception causes the application to exit or crash; otherwise, <c>false</c> if the application can recover from it.</param>
        private void HandleException(ErrorDetails details)
        {
            Logger.Instance.Log(LoggerVerbosity.Basic, "ErrorHandler", $"An exception of type {details.Exception.GetType().FullName} has occurred.");
            Logger.Instance.Log(LoggerVerbosity.Detailed, "ErrorHandler", @$"Exception details:
Message: {details.Exception.Message}
Exception location: {details.Exception.TargetSite}
Stack trace:
{details.Exception.StackTrace}");
            Logger.Instance.Dispose();

            switch (GlobalConfig.Default.SentryConsent)
            {
                case SentryConsent.Ask:
                    using (var crashForm = new ErrorForm(details))
                    {
                        crashForm.ShowDialog();
                    }
                    break;

                case SentryConsent.Declined:
                    Environment.FailFast(null, details.Exception);
                    break;

                case SentryConsent.Accepted:
                    SubmitError(details, GlobalConfig.Default.SubmitLogFiles);
                    break;
            }
        }

        /// <summary>
        /// Handles an exception and takes appropiate action.
        /// </summary>
        /// <param name="exception">The exception to handle.</param>
        /// <param name="severity">How great of an impact this exception causes</param>
        /// <param name="category">What piece of code raised this exception, e.g. TaskbarManager</param>
        /// <param name="message">Custom message of what failed</param>
        public void HandleException(Exception exception, ExceptionSeverity severity = ExceptionSeverity.Handled, string category = null, string message = null)
        {
            category ??= "ErrorHandler";

            Logger.Instance.Log(LoggerVerbosity.Basic, "ErrorHandler", $"An exception of type {details.Exception.GetType().FullName} has occurred.");
            Logger.Instance.Log(LoggerVerbosity.Detailed, "ErrorHandler", @$"Exception details:
Message: {details.Exception.Message}
Exception location: {details.Exception.TargetSite}
Stack trace:
{details.Exception.StackTrace}");
            Logger.Instance.Dispose();
        }

        public void Dispose()
        {
            if (_sentry != null)
            {
                _sentry.Dispose();
                _sentry = null;
            }

            GC.SuppressFinalize(this);
        }
    }
}