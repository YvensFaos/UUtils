using UnityEngine;

namespace Utils
{
    [CreateAssetMenu(fileName = "New Transform Object", menuName = "Utils/Transform Object", order = 0)]
    public class TransformScriptableObject : ScriptableObject
    {
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;
        public Color transformColor = Color.white;

        public void Initialize(Transform transform)
        {
            position = transform.position;
            rotation = transform.rotation.eulerAngles;
            scale = transform.localScale;
        }
    }
}