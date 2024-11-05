using UnityEngine;

namespace Utils
{
    public class ResetMaterialPropertyOnApplicationQuit : MonoBehaviour
    {
        [SerializeField]
        private Material material;
        [SerializeField]
        private string materialProperty;
        [SerializeField]
        private float value;
        
        private void OnApplicationQuit()
        {
            material.SetFloat(materialProperty, value);
        }
    }
}