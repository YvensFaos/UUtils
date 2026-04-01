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
    public static class MathHelper
    {
        public static float NormalizeFromMinusOneToOne(float number)
        {
            return (1 + number) / 2.0f;
        }

        public static bool CloseTo(float a, float b, float epsilon = 0.001f)
        {
            return Mathf.Abs(a - b) < epsilon;
        }
        
        public static int ClosestToDivisible(int number, int divisible)
        {
            var quotient = number / divisible;
            var lowerMultiple = quotient * divisible;
            var upperMultiple = (quotient + 1) * divisible;
            return number - lowerMultiple < upperMultiple - number ? lowerMultiple : upperMultiple;
        }
        
        public static float ClosestToDivisibleFloat(float number, float divisible)
        {
            var quotient = number / divisible;
            var closest = Mathf.Round(quotient);
            return closest * divisible;
        }
    }
}