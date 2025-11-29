/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
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