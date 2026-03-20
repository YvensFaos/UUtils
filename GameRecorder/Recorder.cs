using System.Collections.Generic;

namespace UUtils.GameRecorder
{
    public class Recorder
    {
        private string _identifier;
        private List<RecordEntry> _entries;
        private Logger _logger;
        private bool _closed;

        public Recorder(string identifier, string extension = "rec")
        {
            _identifier = identifier;
            _entries = new List<RecordEntry>();
            _logger = new Logger(DebugUtils.DebugType.Regular);
            _logger.StartNewLogFile($"{identifier}.{extension}");
        }

        public void RecordNewEntry(RecordEntry newEntry)
        {
            if (_closed) return;
            _entries.Add(newEntry);
            _logger.AddLine(newEntry.ToString(), DebugUtils.DebugType.Regular, false);
        }

        public void Stop()
        {
            _logger.Dispose();
            _closed = true;
        }
        
        public IReadOnlyList<RecordEntry> GetRecordEntries => _entries;
    }
}