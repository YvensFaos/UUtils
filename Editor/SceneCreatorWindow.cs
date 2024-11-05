using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Utils.Editor
{
    public class SceneCreatorWindow : EditorWindow
    {
        private SceneBuilderScriptableObject prefabListSO;
        
        [MenuItem("Utils/Scene Creator Window")]
        private static void ShowWindow()
        {
            var window = GetWindow<SceneCreatorWindow>();
            window.titleContent = new GUIContent("Scene Creator");
            window.Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("Scene Creator", EditorStyles.boldLabel);
            prefabListSO = EditorGUILayout.ObjectField("Prefab List", prefabListSO, typeof(SceneBuilderScriptableObject), false) as SceneBuilderScriptableObject;

            if (GUILayout.Button("Create Scene"))
            {
                CreateNewScene();
            }
            if (GUILayout.Button("Load Prefabs to Scene"))
            {
                LoadPrefabsToScene();
            }
        }

        private void CreateNewScene()
        {
            EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
            LoadPrefabsToScene();
        }

        private void LoadPrefabsToScene()
        {
            if (prefabListSO == null)
            {
                DebugUtils.DebugLogErrorMsg("SceneBuilderScriptableObject was not assigned!");
                return;
            }
            prefabListSO.prefabList.ForEach(prefab => { PrefabUtility.InstantiatePrefab(prefab); });
        }
    }
}