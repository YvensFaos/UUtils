using UnityEngine;

namespace UUtils
{
    public class ResetMaterialOnApplicationQuit : MonoBehaviour
    {
        [SerializeField]
        private Material material;
        [SerializeField]
        private Material resetTo;
        
        private void OnApplicationQuit()
        {
            material.CopyPropertiesFromMaterial(resetTo);
        }
    }
}