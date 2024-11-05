using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class PhysicsHelper
    {
        //TODO move to a non utils class since it depends on the PlayerController script
        // public static Vector3 GetPlayerOffsetPosition(PlayerController player, Vector3 offset)
        // {
        //     return player.transform.position + ((player.FacingLeft? -1 : 1) * offset);
        // }
        
        public static RaycastHit2D CircleCollideAround(Vector3 position, float radius, LayerMask layerMask)
        {
            return Physics2D.CircleCast(position, radius, Vector3.right, 0.1f, layerMask);
        }
        
        public static IEnumerable<RaycastHit2D> CircleCollideAroundAll(Vector3 position, float radius, LayerMask layerMask)
        {
            return Physics2D.CircleCastAll(position, radius, Vector3.right, 0.1f, layerMask);
        }
    }
}