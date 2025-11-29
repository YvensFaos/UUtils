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
    public static class RandomHelper<T>
    {
        public static T GetRandomFromList(List<T> list)
        {
            return list.Count == 1 ? list[0] : list[Random.Range(0, list.Count)];
        }
    }

    public static class RandomChanceUtils
    {
        public static bool GetChance(float upTo, float max = 100.0f)
        {
            return Random.Range(0, max) <= upTo;
        }
        
        public static float GetRandomInRange(Vector2 range)
        {
            return Random.Range(range.x, range.y);
        }

        public static int GetRandomInRangeAsInt(Vector2 range)
        {
            return (int)GetRandomInRange(range);
        }
    }

    public static class RandomPointUtils
    {
        public static Vector3 GetRandomPointWithBox(BoxCollider boxCollider)
        {
            var bounds = boxCollider.bounds;
            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z));
        }
        
        public static Vector3 GetRandomPointWithBox2D(BoxCollider2D boxCollider2D)
        {
            var bounds = boxCollider2D.bounds;
            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                0.0f);
        }

        public static Vector3 GetRandomPointWithinCircleRadius(Vector3 position, float radius)
        {
            var randomPoint2D = (Vector2)position + Random.insideUnitCircle * radius;
            return new Vector3(randomPoint2D.x, randomPoint2D.y, 0.0f);
        }
        
        public static Vector3 GetRandomPointWithinCircleCollider2(CircleCollider2D circleCollider, float ignoreRadius = 0.0f)
        {
            if (ignoreRadius != 0.0f && ignoreRadius > 0.0f && ignoreRadius < circleCollider.radius)
            {
                var validRadius = circleCollider.radius - ignoreRadius;
                //Generates a point within the valid (inner) circle
                var randomPoint2D = (Vector2)circleCollider.bounds.center + Random.insideUnitCircle * validRadius;
                var expandTowardsOutCircle = GetRandomPolarCoordinate2D(ignoreRadius);
                //Adds the random point in the ignored radius circle to the randomly generated point
                //which will push it outside the ignored radius
                return new Vector3(randomPoint2D.x + expandTowardsOutCircle.x,
                    randomPoint2D.y + expandTowardsOutCircle.y, 0.0f);
            }
            else
            {
                var randomPoint2D = (Vector2)circleCollider.bounds.center + Random.insideUnitCircle * circleCollider.radius;
                return new Vector3(randomPoint2D.x, randomPoint2D.y, 0.0f);    
            }
        }

        public static Vector2 GetRandomPolarCoordinate2D(float radius)
        {
            var angle = Random.Range(0f, Mathf.PI * 2.0f);
            return new Vector2(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle));
        }
    }
}