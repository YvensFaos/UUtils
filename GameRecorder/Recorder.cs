/*
 * Copyright (c) 2026 Yvens R Serpa [https://github.com/YvensFaos/]
 *
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */

using System.Collections.Generic;

namespace UUtils.GameRecorder
{
    public class Recorder
    {
        private string _identifier;
        private List<RecordEntry> _entries;
        private Logger _logger;
        private bool _closed;
        private bool _disposed;
        
        public Recorder(string identifier, string extension = ".rex")
        {
            _identifier = identifier;
            _entries = new List<RecordEntry>();
            _logger = new Logger(DebugUtils.DebugType.Regular);
            _logger.StartNewLogFile($"{identifier}",$"{extension}");
        }

        public void RecordNewEntry(RecordEntry newEntry)
        {
            if (_closed || _disposed) return;
            _entries.Add(newEntry);
            _logger.AddLine(newEntry.ToString(), DebugUtils.DebugType.Regular, false, false);
        }

        public void Stop()
        {
            _logger.Dispose();
            _closed = true;
        }
        
        public IReadOnlyList<RecordEntry> GetRecordEntries => _entries;
        
        private void Dispose()
        {
            if (_disposed) return;
            _logger.Dispose();
            _disposed = true;
        }

        ~Recorder()
        {
            Dispose();
        }
    }
}