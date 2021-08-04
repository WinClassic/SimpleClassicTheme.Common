using System;

namespace SimpleClassicTheme.Common.Performance
{
    public partial class TimingDebugger
    {
        public record Region
        {
            public string Label { get; init; }

            public TimeSpan Timestamp { get; init; }

            public TimeSpan EndTime { get; init; }

            public TimeSpan Duration => EndTime - Timestamp;
        }
    }

}