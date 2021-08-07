using System;

namespace SimpleClassicTheme.Common.ErrorHandling
{
    public record ErrorDetails
    {
        public Exception Exception { get; init; }

        public bool Fatal { get; init; }

        public ErrorHandler Handler { get; init; }
    }
}