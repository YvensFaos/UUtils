using UnityEditor;
using UnityEngine;

namespace UUtils.Editor
{
    [CustomPropertyDrawer(typeof(CacheHelper<>))]
    public class CacheHelperEditor: PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.LabelField(position, label.text);
            EditorGUI.EndProperty();
        }
    }
}