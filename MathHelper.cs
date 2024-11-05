using UnityEngine;

namespace Utils
{
    public static class MathHelper
    {
        public static float NormalizeFromMinusOneToOne(float number)
        {
            return (1 + number) / 2.0f;
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