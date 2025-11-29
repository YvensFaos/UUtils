/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
using UnityEngine;

namespace UUtils
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