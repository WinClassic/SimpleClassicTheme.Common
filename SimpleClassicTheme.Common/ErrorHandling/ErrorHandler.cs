using Sentry;

using SimpleClassicTheme.Common.Configuration;
using SimpleClassicTheme.Common.ErrorHandling.Forms;
using SimpleClassicTheme.Common.Logging;

using System;
using System.Windows.Forms;

namespace SimpleClassicTheme.Common.ErrorHandling
{
    public class ErrorHandler
    {
        public string SentryDsn { get; set; }

        public static void ShowErrorCollectionDetails()
        {
            const string url = "https://github.com/WinClassic/SimpleClassicTheme.Common/wiki/Sentry-integration";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        public void SubscribeToErrorEvents()
        {
            Application.ThreadException += (sender, e) =>
            {
                HandleException(new ErrorDetails
                {
                    Exception = e.Exception,
                    Fatal = false,
                    SentryDsn = SentryDsn,
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
                    SentryDsn = SentryDsn,
                });
            };
        }

        internal static void SubmitError(ErrorDetails details, bool submitLog)
        {
            using (SentrySdk.Init(o =>
            {
                o.Dsn = details.SentryDsn;
                o.MaxBreadcrumbs = 50;
#if DEBUG
                o.Debug = true;
#endif
            }))
            {
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
        }

        /// <summary>
        /// Handles an exception and takes appropiate action.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="fatal"><c>true</c> if the exception causes the application to exit or crash; otherwise, <c>false</c> if the application can recover from it.</param>
        private static void HandleException(ErrorDetails details)
        {
            Logger.Instance.Log(LoggerVerbosity.Basic, "ErrorHandler", $"An exception of type {details.Exception.GetType().FullName} has occurred.");
            Logger.Instance.Log(LoggerVerbosity.Detailed, "ErrorHandler", @$"Exception details:
Message: {details.Exception.Message}
Exception location: {details.Exception.TargetSite}
Stack trace:
{details.Exception.StackTrace}");
            Logger.Instance.Dispose();

            // if (fatal)
            {
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
        }
    }
}