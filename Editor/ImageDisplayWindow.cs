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
    public class ImageDisplayWindow : EditorWindow
    {
        [SerializeField]
        private Texture2D selectedImage;
        [SerializeField]
        private float scaleFactor = 1.0f;

        [MenuItem("Utils/Image Display Window")]
        public static void ShowWindow()
        {
            GetWindow<ImageDisplayWindow>("Image Display Window");
        }

        private void OnGUI()
        {
            GUILayout.Label("Image Display Window", EditorStyles.boldLabel);
            
            selectedImage = EditorGUILayout.ObjectField("Image", selectedImage, typeof(Texture2D), false) as Texture2D;
            
            if (selectedImage == null) return;
            EditorGUILayout.Space(15.0f);
            
            var labelStyle = new GUIStyle(EditorStyles.label)
            {
                fontSize = 14,
                fontStyle = FontStyle.Bold
            };
            
            EditorGUILayout.LabelField(selectedImage.name, labelStyle);
            EditorGUILayout.Space(15.0f);
            scaleFactor = EditorGUILayout.Slider("Scale", scaleFactor, 0.1f, 2.0f);

            var aspectRatio = (float) selectedImage.width / selectedImage.height;
            var imageRect = GUILayoutUtility.GetAspectRect(aspectRatio, GUILayout.ExpandWidth(true));
            var scaledImageRect = new Rect(imageRect.position, imageRect.size * scaleFactor);
            GUI.DrawTexture(scaledImageRect, selectedImage, ScaleMode.ScaleToFit);
        }
    }
}