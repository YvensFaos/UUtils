using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Utils
{
    public class TilemapInfo : MonoBehaviour
    {
    
        [SerializeField]
        private TilemapRenderer tileMapRenderer;

        [Button("Get info")]
        private void GetInfo()
        {
            var tileMapBounds = tileMapRenderer.bounds;

            // Access the dimensions of the bounds
            var width = tileMapBounds.size.x;
            var height = tileMapBounds.size.y;

            // Output the bounds and dimensions
            DebugUtils.DebugLogMsg("Tile Map Bounds: " + tileMapBounds);
            DebugUtils.DebugLogMsg("Width: " + width);
            DebugUtils.DebugLogMsg("Height: " + height);
        }
    }
}
