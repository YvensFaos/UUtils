using UnityEditor;
using UnityEngine;

namespace Utils.Editor
{
    public abstract class CustomIconEditor<T> : UnityEditor.Editor where T : ScriptableObject
    {
        private Texture2D croppedTexture;

        public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
        {
            if (croppedTexture != null) return croppedTexture;
            var scriptableObject = AssetDatabase.LoadAssetAtPath<T>(assetPath);
            if (scriptableObject == null || !CheckValidSpriteInfo(scriptableObject))
                return base.RenderStaticPreview(assetPath, subAssets, width, height);

            croppedTexture = GetSpriteTexture.GetTextureFromSprite(GetSprite(scriptableObject));
            return croppedTexture;
        }

        protected abstract bool CheckValidSpriteInfo(T scriptableObject);
        protected abstract Sprite GetSprite(T scriptableObject);
    }
}