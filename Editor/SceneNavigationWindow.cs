using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Utils.Editor
{
    public class SceneNavigationWindow : EditorWindow
    {
        private Vector2 scrollPos;

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
            
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

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