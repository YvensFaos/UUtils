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
        private static DebugType enabledDebugTypes = DebugType.Regular | DebugType.System | DebugType.Warning | DebugType.Error;
        #else
        private static DebugType enabledDebugTypes = DebugType.None;
        #endif
        
        private static bool _debug = true;

        public static bool SetDebug
        {
            get => _debug;
            set => _debug = value;
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

        public static void DebugLogMsg(string msg)
        {
            if (!SetDebug) return;
            DebugLogMsg(msg, DebugType.Verbose);
        }
        
        public static void DebugLogMsg(string msg, DebugType type)
        {
            if (!SetDebug) return;
            if (enabledDebugTypes.HasFlag(type))
            {
                Debug.Log(GetColoredMessage(msg, type));
            }
        }

        public static void DebugAssertion(bool condition, string msg)
        {
            if (!SetDebug) return;
            Debug.Assert(condition, msg);
        }

        public static void DebugLogErrorMsg(string msg)
        {
            if (!SetDebug) return;
            Debug.LogError(msg);
        }

        public static void DebugLogWarningMsg(string msg)
        {
            if (!SetDebug) return;
            Debug.LogWarning(msg);
        }

        public static void DebugLogException(Exception exception)
        {
            if (!SetDebug) return;
            Debug.LogError(exception.ToString());
            Debug.LogError(exception.StackTrace);
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