/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
using System;
using System.Globalization;
using System.IO;
using System.Text;
using UnityEngine;

namespace UUtils
{
    public sealed class Logger : IDisposable
    {
        private const string DefaultLOGFolder = "Logs";
        private const string DefaultFileExtension = ".log";
        private readonly object _lockObject = new();
        private readonly DebugUtils.DebugType _minimumLogLevel;
        private readonly StringBuilder _stringBuilder = new(256);
        private StreamWriter _streamWriter;
        private FileStream _fileStream;
        private bool _disposed;
        private string CurrentFilePath { get; set; }
        
        public Logger(DebugUtils.DebugType minimumLogLevel = DebugUtils.DebugType.System)
        {
            _minimumLogLevel = minimumLogLevel;
            
            // Create default logs directory if it doesn't exist
            var defaultPath = GetDefaultLogsDirectory();
            if (!Directory.Exists(defaultPath))
            {
                Directory.CreateDirectory(defaultPath);
            }
        }

        public string StartNewLogFile(string logFileName = "log_")
        {
            return StartNewLogFile(logFileName, GetDefaultLogsDirectory());
        }

        public string StartNewLogFile(string fileName, string directoryPath, bool appendIfExists = false)
        {
            lock (_lockObject)
            {
                CloseLogFile();
                if (string.IsNullOrEmpty(directoryPath))
                {
                    directoryPath = GetDefaultLogsDirectory();
                }
                
                if (!Directory.Exists(directoryPath))
                {
                    try
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                    catch (Exception ex)
                    {
                        DebugUtils.DebugLogException(ex);
                        return null;
                    }
                }

                if (!fileName.EndsWith(DefaultFileExtension, StringComparison.OrdinalIgnoreCase))
                {
                    fileName += DefaultFileExtension;
                }

                var fullPath = Path.Combine(directoryPath, fileName);

                try
                {
                    _fileStream = new FileStream(fullPath,
                        appendIfExists ? FileMode.Append : FileMode.Create,
                        FileAccess.Write,
                        FileShare.Read);
                    _streamWriter = new StreamWriter(_fileStream, Encoding.UTF8);
                    _streamWriter.AutoFlush = true;
                    CurrentFilePath = fullPath;
                    DebugUtils.DebugLogMsg($"Log file started: {fullPath}.", DebugUtils.DebugType.System);
                    return fullPath;
                }
                catch (Exception ex)
                {
                    DebugUtils.DebugLogException(ex);
                    CloseLogFile();
                    return null;
                }
            }
        }

        public void AddLine(string message, DebugUtils.DebugType debugType = DebugUtils.DebugType.System,
            bool includeTimestamp = true)
        {
            if ((int)debugType < (int)_minimumLogLevel)
                return;

            lock (_lockObject)
            {
                if (_streamWriter == null)
                {
                    DebugUtils.DebugLogErrorMsg("Logger not initialized. Call StartNewLogFile first.");
                    return;
                }

                try
                {
                    _stringBuilder.Clear();
                    if (includeTimestamp)
                    {
                        _stringBuilder.Append(GetTimestamp());
                        _stringBuilder.Append(";");
                    }

                    _stringBuilder.Append($"[{debugType.ToString().ToUpper()}];");
                    _stringBuilder.Append(message);

                    var logLine = _stringBuilder.ToString();
                    _streamWriter.WriteLine(logLine);
                }
                catch (Exception ex)
                {
                    Debug.LogError($"Failed to write to log file: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Close the current log file
        /// </summary>
        private void CloseLogFile()
        {
            lock (_lockObject)
            {
                try
                {
                    if (_streamWriter != null)
                    {
                        _streamWriter.Flush();
                        _streamWriter.Close();
                        _streamWriter.Dispose();
                        _streamWriter = null;
                    }

                    if (_fileStream != null)
                    {
                        _fileStream.Close();
                        _fileStream.Dispose();
                        _fileStream = null;
                    }

                    DebugUtils.DebugLogMsg($"Log file closed: {CurrentFilePath}.", DebugUtils.DebugType.System);

                    CurrentFilePath = null;
                }
                catch (Exception ex)
                {
                    DebugUtils.DebugLogException(ex);
                }
            }
        }

        private static string GetDefaultLogsDirectory()
        {
#if UNITY_EDITOR
            var basePath = Application.dataPath;
#else
            var basePath = Application.persistentDataPath;
#endif
            return Path.Combine(basePath, DefaultLOGFolder);
        }

        private static string GetTimestamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        public static string GetSimplifiedTimestamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss", CultureInfo.InvariantCulture);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                CloseLogFile();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Logger()
        {
            Dispose(false);
        }
    }
}