/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
using System.IO;
using UnityEngine;

namespace UUtils
{
    public static class TextureHelper
    {
        public static void SaveRenderTexture(RenderTexture sourceRenderTexture, string savePath)
        {
            var tempTexture = new Texture2D(sourceRenderTexture.width, sourceRenderTexture.height, TextureFormat.ARGB32, false);
            RenderTexture.active = sourceRenderTexture;
            tempTexture.ReadPixels(new Rect(0, 0, sourceRenderTexture.width, sourceRenderTexture.height), 0, 0);
            tempTexture.Apply();
            RenderTexture.active = null;

            var textureBytes = tempTexture.EncodeToPNG();
            File.WriteAllBytes(savePath, textureBytes);
        }

        public static void LoadImageToRenderTexture(ref RenderTexture destinationRenderTexture, string loadPath)
        {
            var loadedTexture = new Texture2D(destinationRenderTexture.width, destinationRenderTexture.height);
            var imageBytes = File.ReadAllBytes(loadPath);
            loadedTexture.LoadImage(imageBytes);
            
            Graphics.Blit(loadedTexture, destinationRenderTexture);
        }
    }
}