using System;
using System.IO;
using System.Threading;
using WebApiReferenceImpl.Core.Threading;

namespace WebApiReferenceImpl.Core.Logging
{
    public class FileLogger : Disposable, ILogger
    {
        private readonly ReaderWriterLockSlim _fileLock;
        private readonly string _filePath;
        private readonly StreamWriter _logWriter;
        // ReSharper disable InconsistentNaming
        private const string OUTPUT_FORMAT = @"[{0}:{1}:{2}] {3}";
        // ReSharper restore InconsistentNaming

        public FileLogger(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(@"filePath parameter can not be null or empty string");
            }

            _filePath = filePath;
            _fileLock = Locks.GetLockInstance(LockRecursionPolicy.NoRecursion);

            var fi = new FileInfo(_filePath);

            if (fi.Exists)
            {
                fi.MoveTo(string.Format(@"{0}\{1}.{2}.log", fi.DirectoryName, fi.Name.Replace(fi.Extension, string.Empty), DateTime.Now.Ticks));
            }

            _logWriter = new StreamWriter(_filePath);
        }

        public void LogMessage(string message, LogSeverity severity)
        {
            ThrowExceptionIfDisposed();

            using (new WriteLock(_fileLock))
            {
                var now = SystemTime.Now;
                _logWriter.WriteLine(OUTPUT_FORMAT, severity, 
                                     now.LocalDateTime.ToShortDateString(), 
                                     now.LocalDateTime.ToShortTimeString(), 
                                     message);
            }
        }

        protected override void DisposeManagedResources()
        {
            if (_logWriter != null)
            {
                _logWriter.Dispose();
            }

            base.DisposeManagedResources();
        }
    }
}