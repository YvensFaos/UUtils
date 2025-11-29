/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
using System.Collections.Generic;
using UnityEngine;

namespace UUtils
{
    public static class PhysicsHelper
    {
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