using System;

namespace SimpleClassicTheme.Common.Performance
{
    public partial class TimingDebugger
    {
        public class Marker : IDisposable
        {
            public TimingDebugger Debugger { get; }

            public string Label { get; }

            public TimeSpan StartTime { get; }

            public Marker(TimingDebugger debugger, string label)
            {
                StartTime = debugger.Elapsed;
                Debugger = debugger;
                Label = label;
            }

            public void Dispose()
            {
                if (Debugger._stopwatch.IsRunning)
                {
                    var region = new Region
                    {
                        Timestamp = StartTime,
                        EndTime = Debugger.Elapsed,
                        Label = Label,
                    };

                    Debugger.Times.Add(region);
                }
            }
        }
    }

}