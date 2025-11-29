/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace UUtils.Editor
{
    public class SceneNavigationWindow : EditorWindow
    {
        private Vector2 _scrollPos;

        [MenuItem("Utils/Scene Navigation Window")]
        public static void ShowWindow()
        {
            GetWindow<SceneNavigationWindow>("Scene Navigation");
        }

        private void OnGUI()
        {
            var labelStyle = new GUIStyle(EditorStyles.label)
            {
                fontSize = 14,
                fontStyle = FontStyle.Bold
            };
            
            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);

            EditorGUILayout.LabelField("Build Scenes:", labelStyle);
            var buildScenes = EditorBuildSettings.scenes;
            foreach (var scene in buildScenes)
            {
                if (!scene.enabled)
                {
                    continue;
                }

                if (GUILayout.Button($"Open [{scene.path.Split('/').Last()}]"))
                {
                    EditorSceneManager.OpenScene(scene.path);
                }
            }
            EditorGUILayout.EndScrollView();
        }
    }
}