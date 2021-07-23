using System;

namespace SimpleClassicTheme.Common.ErrorHandling
{
    public record ErrorDetails
    {
        public Exception Exception { get; init; }

        public bool Fatal { get; init; }

        public string SentryDsn { get; init; }
    }
}