using UnityEngine;

namespace Utils
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
