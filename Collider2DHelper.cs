using UnityEngine;

namespace Utils
{
    public static class Collider2DHelper
    {
        public static float GenericRadiusFrom(Collider2D collider2D)
        {
            var bounds = collider2D.bounds;
            var diagonalLength = bounds.size.magnitude;
            return diagonalLength / 2f;
        }
    }
}