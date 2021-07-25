﻿using System;

namespace SimpleClassicTheme.Common.Configuration
{
    public enum SentryConsent
    {
        /// <summary>
        /// The user will see the crash dialog on every crash.
        /// </summary>
        Ask = 0,

        /// <summary>
        /// The application will crash automatically.
        /// </summary>
        Declined = 1,

        /// <summary>
        /// The application will submit the crash automatically and then exit.
        /// </summary>
        Accepted = 2,
    }

    /// <summary>
    /// Config class that applies to every SimpleClassicTheme application
    /// </summary>
    public sealed class GlobalConfig : ConfigBase<GlobalConfig>
    {
        [Obsolete("Do not use this constructor, use GlobalConfig.Default instead.", true)]
        public GlobalConfig() : base("SimpleClassicThemeCommon", ConfigType.Global)
        {
        }

        /// <summary>
        /// User's consent preferences towards Sentry reports
        /// </summary>
        public SentryConsent SentryConsent { get; set; } = SentryConsent.Ask;

        /// <summary>
        /// Whether to provide log files alongside crash reports in Sentry.
        /// </summary>
        public bool SubmitLogFiles { get; set; } = true;
    }
}