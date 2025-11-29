/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
using UnityEngine;

namespace UUtils
{
    public static class GetSpriteTexture
    {
        public static Texture2D GetTextureFromSprite(Sprite sprite)
        {
            var spriteRect = sprite.rect;
            var fullTexture = sprite.texture;
            var croppedTexture = new Texture2D((int)spriteRect.width, (int)spriteRect.height);
            var pixels = fullTexture.GetPixels((int)spriteRect.x, (int)spriteRect.y, (int)spriteRect.width,
                (int)spriteRect.height);
            croppedTexture.SetPixels(pixels);
            croppedTexture.Apply();
            return croppedTexture;
        }
    }
}
