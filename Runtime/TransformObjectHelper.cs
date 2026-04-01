/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
using NaughtyAttributes;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UUtils
{
    public class TransformObjectHelper : MonoBehaviour
    {
        [SerializeField]
        private TransformScriptableObject transformReference;
        [SerializeField]
        private string saveTo = "Assets/";
        private Transform _selfTransform;

        private void Awake()
        {
            _selfTransform = transform;
        }

        // ReSharper disable once UnusedMember.Local
        [Button("Match Reference")]
        private void UpdateTransformToReference()
        {
            if (transformReference == null) return;
            _selfTransform.position = transformReference.position;
            _selfTransform.rotation = Quaternion.Euler(transformReference.rotation);
            _selfTransform.localScale = transformReference.scale;
        }
        
        [Button("Match Transform")]
        private void UpdateReferenceToTransform()
        {
            if (transformReference == null) return;
            transformReference.Initialize(_selfTransform);
            
            #if UNITY_EDITOR
            EditorUtility.SetDirty(transformReference);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            #endif
        }

        // ReSharper disable once UnusedMember.Local
        [Button("Create Transform Reference SO")]
        private void CreateTransformReference()
        {
            var newTransformReference = ScriptableObject.CreateInstance<TransformScriptableObject>();
            transformReference = newTransformReference;
            UpdateReferenceToTransform();
            
            #if UNITY_EDITOR
            AssetDatabase.CreateAsset(newTransformReference, $"{saveTo}{name}.asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            #endif
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = transformReference != null ? transformReference.transformColor : Color.white;
            if (_selfTransform == null) _selfTransform = transform;
            Gizmos.DrawWireCube(_selfTransform.position, _selfTransform.localScale);
        }
    }
}