using UnityEditor;
using UnityEngine;

namespace Utils.Editor
{
    public static class TransformScriptableObjectGenerator
    {
        private const string Path = "Assets/Database/Teleport/";

        [MenuItem("Utils/Create Transform Scriptable Object")]
        public static void SelectConstants()
        {
            if (Selection.activeTransform != null)
            {
                var selectedName = Selection.activeGameObject.name;
                var selectedTransform = Selection.activeTransform;
                var transformScriptableObject = ScriptableObject.CreateInstance<TransformScriptableObject>();
                transformScriptableObject.position = selectedTransform.position;
                transformScriptableObject.rotation = selectedTransform.rotation.eulerAngles;
                transformScriptableObject.scale = selectedTransform.localScale;

                var savePath = $"{Path}{selectedName}.asset";
                AssetDatabase.CreateAsset(transformScriptableObject, savePath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                
                var obj = AssetDatabase.LoadMainAssetAtPath(savePath);
                if (obj == null) return;
                Selection.activeObject = obj;
                EditorGUIUtility.PingObject(obj);
            }
        }
    }
}