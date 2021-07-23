using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SimpleClassicTheme.Common.Logging
{
    public enum LoggerVerbosity : int
    {
        /// <summary>
        /// Don't log anything.
        /// </summary>
        None = 0,

        /// <summary>
        /// Log messages about basic information.
        /// </summary>
        Basic = 1,

        /// <summary>
        /// Log messages about program flow.
        /// </summary>
        Detailed = 2,

        /// <summary>
        /// Log messages for debugging or about received values.
        /// </summary>
        Verbose = 3
    }

    public class Logger : IDisposable
    {
        private readonly static object s_instanceLock = new();
        private static Logger s_instance;

        private readonly object _writingLock = new();

        private FileStream _fileStream;

        private StreamWriter _streamWriter;

        public static Logger Instance
        {
            get
            {
                lock (s_instanceLock)
                {
                    if (s_instance == null)
                        s_instance = new Logger();

                    return s_instance;
                }
            }
        }

        /// <summary>
        /// Gets the file path that this <see cref="Logger"/> is writing to.
        /// </summary>
        public string FilePath { get; private set; }

        public LoggerVerbosity Verbosity { get; private set; }

        /// <summary>
        /// Clean up any resources used.
        /// </summary>
        /// <remarks>Only use this method when you know that the application hosting this instance isn't using it anymore.</remarks>
        public void Dispose()
        {
            Log(LoggerVerbosity.Basic, "Logger", "Shutting down logger");

            _streamWriter?.Dispose();
            _fileStream?.Dispose();

            _streamWriter = null;
            _fileStream = null;
        }

        public void Initialize(LoggerVerbosity verbosity)
        {
            Verbosity = verbosity;

            if (Verbosity == LoggerVerbosity.None)
                return;

            _fileStream = new FileStream(FilePath = "latest.log", FileMode.Create, FileAccess.Write, FileShare.Read);
            _streamWriter = new StreamWriter(_fileStream) { AutoFlush = true };

            Log(LoggerVerbosity.Basic, "Logger", "Succesfully initialized logger");

            DumpSystemInformation();
        }

        public void Log(LoggerVerbosity verbosity, string source, string text)
        {
            if (Debugger.IsAttached)
            {
                Debug.WriteLine(text, source);
            }

            if ((verbosity == LoggerVerbosity.None) || (_streamWriter == null))
            {
                return;
            }

            if (verbosity <= Verbosity)
            {
                lock (_writingLock)
                {
                    _streamWriter.WriteLine($"[{verbosity,-8}][{source,-24}]: {text}");
                }
            }
        }

        private void DumpSystemInformation()
        {
            Log(LoggerVerbosity.Detailed, "SystemDump", "Performing quick system dump");
            Log(LoggerVerbosity.Detailed, "SystemDump", $"OS: {RuntimeInformation.OSDescription} {RuntimeInformation.OSArchitecture}");

            // if (ApplicationEntryPoint.SCTCompatMode)
            //     Log(LoggerVerbosity.Detailed, "SystemDump", $"SCT version: {Assembly.LoadFrom("C:\\SCT\\SCT.exe").GetName().Version}");

            Log(LoggerVerbosity.Detailed, "SystemDump", $"SCT Taskbar version: {Assembly.GetExecutingAssembly().GetName().Version}");
        }
    }
}