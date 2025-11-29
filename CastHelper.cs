/*
 * Copyright (c) 2025 Yvens R Serpa [https://github.com/YvensFaos/]
 * 
 * This work is licensed under the Creative Commons Attribution 4.0 International License.
 * To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/
 * or see the LICENSE file in the root directory of this repository.
 */
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UUtils
{
    public static class CastHelper
    {
        public static IEnumerable<T> TryCastTo<T, S>(IEnumerable<S> originalList)
        {
            return originalList.Cast<T>();
        }
        
        public static IEnumerable<GameObject> GameObjectsFromRaycast2D(IEnumerable<RaycastHit2D> originalList)
        {
            return originalList.Select(raycast => raycast.collider.gameObject);
        }

        public static IEnumerable<T> CastToFromGameObject<T>(IEnumerable<GameObject> originalList)
        {
            var cast = new List<T>();
            foreach (var gameObject in originalList)
            {
                if (gameObject.TryGetComponent<T>(out T component))
                {
                    cast.Add(component);
                }
            }

            return cast;
        }
    }
}