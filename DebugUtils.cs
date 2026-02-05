/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 *
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */

using System;
using UnityEngine;

namespace UUtils
{
    public static class DebugUtils
    {
        [Flags]
        public enum DebugType
        {
            None = 0,
            Regular = 1,
            System = 2,
            Temporary = 4,
            Warning = 8,
            Error = 16,
            Verbose = 32
        }

#if UNITY_EDITOR
        public static DebugType enabledDebugTypes =
            DebugType.Regular | DebugType.System | DebugType.Warning | DebugType.Error;
        public static DebugType enabledDebugLogTypes =
            DebugType.Regular | DebugType.System | DebugType.Warning | DebugType.Error;
#else
        public static DebugType enabledDebugTypes = DebugType.None;
        public static DebugType enabledDebugLogTypes = DebugType.None;
#endif

        private static bool _logToFile = false;
        private static bool _debug = true;
        private static Logger _logger;

        public static bool SetDebug
        {
            get => _debug;
            set => _debug = value;
        }

        public static void LogToFile(string fileName)
        {
            _logToFile = true;
            _logger = new Logger(enabledDebugLogTypes);
            _logger.StartNewLogFile(fileName);
        }

        public static void CloseLog()
        {
            _logToFile = false;
            _logger.Dispose();
        }

        public static void DebugArea(Vector3 position, float distance, float duration = 3.0f)
        {
            if (!SetDebug) return;
            Debug.DrawLine(position, position + distance * Vector3.right, Color.blue, duration);
            Debug.DrawLine(position, position + distance * Vector3.up, Color.green, duration);
            Debug.DrawLine(position, position + distance * Vector3.forward, Color.red, duration);
        }

        public static void DebugCircle(Vector3 position, Color color, float radius, int segments = 12,
            float duration = 3.0f)
        {
            if (!SetDebug) return;
            if (radius <= 0.0f || segments <= 0) return;

            var angleStep = (360.0f / segments) * Mathf.Deg2Rad;
            var lineStart = Vector3.zero;
            var lineEnd = Vector3.zero;

            for (var i = 0; i < segments; i++)
            {
                lineStart.x = Mathf.Cos(angleStep * i) * radius;
                lineStart.y = Mathf.Sin(angleStep * i) * radius;
                lineEnd.x = Mathf.Cos(angleStep * (i + 1)) * radius;
                lineEnd.y = Mathf.Sin(angleStep * (i + 1)) * radius;
                Debug.DrawLine(lineStart + position, lineEnd + position, color, duration);
            }
        }

        public static void DebugLine(Vector3 start, Vector3 end, Color color, float duration = 3.0f)
        {
            if (!SetDebug) return;
            Debug.DrawLine(start, end, color, duration);
        }

        public static void DebugLogMsg(string msg)
        {
            if (!SetDebug) return;
            DebugLogMsg(msg, DebugType.Verbose);
        }

        public static void DebugLogMsg(string msg, DebugType type, bool fromLog = false)
        {
            if (!SetDebug) return;
            if (enabledDebugTypes.HasFlag(type))
            {
                Debug.Log(GetColoredMessage(msg, type));
            }

            if (!fromLog && _logToFile)
            {
                _logger.AddLine(msg, type);
            }
        }

        public static void DebugAssertion(bool condition, string msg, bool fromLog = false)
        {
            if (!SetDebug) return;
            Debug.Assert(condition, msg);
            if (!fromLog && _logToFile)
            {
                _logger.AddLine(msg, DebugType.Warning);
            }
        }

        public static void DebugLogErrorMsg(string msg, bool fromLog = false)
        {
            if (!SetDebug) return;
            Debug.LogError(msg);
            if (!fromLog && _logToFile)
            {
                _logger.AddLine(msg, DebugType.Error);
            }
        }

        public static void DebugLogWarningMsg(string msg, bool fromLog = false)
        {
            if (!SetDebug) return;
            Debug.LogWarning(msg);
            if (!fromLog && _logToFile)
            {
                _logger.AddLine(msg, DebugType.Warning);
            }
        }

        public static void DebugLogException(Exception exception, bool fromLog = false)
        {
            if (!SetDebug) return;
            Debug.LogError(exception.ToString());
            Debug.LogError(exception.StackTrace);
            if (!fromLog && _logToFile) return;
            _logger.AddLine(exception.ToString(), DebugType.Error);
            _logger.AddLine(exception.StackTrace, DebugType.Error);
        }

        private static string GetColoredMessage(string msg, DebugType type)
        {
            var color = type switch
            {
                DebugType.Regular => "white",
                DebugType.System => "cyan",
                DebugType.Temporary => "yellow",
                DebugType.Warning => "orange",
                DebugType.Error => "red",
                DebugType.Verbose => "green",
                _ => "white"
            };
            return $"<color={color}>{msg}</color>";
        }
    }
}