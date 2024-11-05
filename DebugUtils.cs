using System;
using UnityEngine;

namespace UUtils
{
    public static class DebugUtils
    {
        private static bool _debug = true;

        public static bool SetDebug
        {
            get => _debug;
            set => _debug = value;
        }

        public static void DebugArea(Vector3 position, float distance, float duration = 3.0f)
        {
            Debug.DrawLine(position, position + distance * Vector3.right, Color.blue, duration);
            Debug.DrawLine(position, position + distance * Vector3.up, Color.green, duration);
            Debug.DrawLine(position, position + distance * Vector3.forward, Color.red, duration);
        }

        public static void DebugLogMsg(string msg)
        {
            if (!SetDebug) return;
            Debug.Log(msg);
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

        public static void DebugLogException(Exception exception)
        {
            if (!SetDebug) return;
            Debug.LogError(exception.ToString());
            Debug.LogError(exception.StackTrace);
        }
    }
}