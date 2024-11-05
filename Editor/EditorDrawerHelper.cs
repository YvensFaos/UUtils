using UnityEditor;
using UnityEngine;

namespace UUtils.Editor
{
    public static class EditorDrawerHelper
    {
        public static void DrawActiveBox(string text, bool activeBool, float widthRatio = 1.0f, float height = 20.0f)
        {
            var color = GUI.backgroundColor;
            GUI.backgroundColor = activeBool ? Color.green : Color.red;
            GUILayout.Box($"{text}", GUILayout.Width(EditorGUIUtility.currentViewWidth / widthRatio), GUILayout.Height(height));
            GUI.backgroundColor = color;
        }
    }
}