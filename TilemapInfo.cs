using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UUtils
{
    public class TilemapInfo : MonoBehaviour
    {
        [SerializeField] private TilemapRenderer tileMapRenderer;
        [SerializeField] private bool getInfoOnAwake = false;
        [SerializeField] private Vector2Int dimensions;
        private Bounds _tileMapBounds;
        private bool _initialized = false;

        private void Awake()
        {
            if (getInfoOnAwake)
            {
                GetInfo();
            }
        }

        [Button("Get info")]
        private void GetInfo()
        {
            _tileMapBounds = tileMapRenderer.bounds;

            // Access the dimensions of the bounds
            var width = _tileMapBounds.size.x;
            var height = _tileMapBounds.size.y;

            // Save the dimensions
            dimensions = new Vector2Int((int)width, (int)height);
            _initialized = true;

            // Output the bounds and dimensions
            DebugUtils.DebugLogMsg("Tile Map Bounds: " + _tileMapBounds, DebugUtils.DebugType.System);
            DebugUtils.DebugLogMsg("Width: " + width, DebugUtils.DebugType.System);
            DebugUtils.DebugLogMsg("Height: " + height, DebugUtils.DebugType.System);
        }

        public Bounds GetTileMapBounds()
        {
            if (!_initialized)
            {
                GetInfo();
            }

            return _tileMapBounds;
        }

        public Vector2Int GetDimensions()
        {
            if (!_initialized)
            {
                GetInfo();
            }

            return dimensions;
        }
    }
}