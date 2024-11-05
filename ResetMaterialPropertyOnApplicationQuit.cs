using UnityEngine;

namespace UUtils
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