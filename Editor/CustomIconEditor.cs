using UnityEditor;
using UnityEngine;

namespace UUtils.Editor
{
    public abstract class CustomIconEditor<T> : UnityEditor.Editor where T : ScriptableObject
    {
        private Texture2D _croppedTexture;

        public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
        {
            if (_croppedTexture != null) return _croppedTexture;
            var scriptableObject = AssetDatabase.LoadAssetAtPath<T>(assetPath);
            if (scriptableObject == null || !CheckValidSpriteInfo(scriptableObject))
                return base.RenderStaticPreview(assetPath, subAssets, width, height);

            _croppedTexture = GetSpriteTexture.GetTextureFromSprite(GetSprite(scriptableObject));
            return _croppedTexture;
        }

        protected abstract bool CheckValidSpriteInfo(T scriptableObject);
        protected abstract Sprite GetSprite(T scriptableObject);
    }
}