using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SimpleClassicTheme.Common.Performance
{
    public partial class TimingDebugger
    {
        private readonly Stopwatch _stopwatch = new();
        private TimeSpan _regionTimestamp = TimeSpan.Zero;

        public List<Region> Times = new();

        public TimeSpan StopTime { get; private set; }

        public TimeSpan Elapsed => _stopwatch.Elapsed;

        [Obsolete("Use StartRegion instead")]
        public void FinishRegion(string label)
        {
            var region = new Region
            {
                Timestamp = _regionTimestamp,
                EndTime = _stopwatch.Elapsed,
                Label = label,
            };

            Times.Add(region);
            _regionTimestamp = _stopwatch.Elapsed;
            // stopwatch.Reset();
            // stopwatch.Start();
        }

        public Marker StartRegion(string label)
        {
            return new Marker(this, label);
        }

        public void Reset()
        {
            _stopwatch.Reset();
            Times.Clear();
        }

        public void Start()
        {
            _stopwatch.Reset();
            _stopwatch.Start();
            _regionTimestamp = TimeSpan.Zero;
        }

        public void Stop()
        {
            StopTime = _stopwatch.Elapsed;
            _stopwatch.Stop();
        }
        
        public void ShowDialog()
        {
            using (var dialog = new TimingDebuggerForm(this))
            {
                dialog.ShowDialog();
            }
        }

        public void Show()
        {
            var dialog = new TimingDebuggerForm(this);
            dialog.Show();
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var region in Times)
            {
                sb.AppendLine(region.Duration.ToString() + '\t' + region.Label);
            }

            sb.AppendLine(_stopwatch.Elapsed.ToString() + '\t' + "Final bit");

            return sb.ToString();
        }
    }

}