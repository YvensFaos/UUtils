using System.Linq;
using System.Text.RegularExpressions;

namespace UUtils
{
    public static class DiceHelper
    {
        /// <summary>
        /// Roll a die of a given number of sides.
        /// The default value is 6 for a six-sided die.
        /// </summary>
        /// <param name="sides">Number of sides.</param>
        /// <returns></returns>
        public static int RollDie(int sides = 6)
        {
            return UnityEngine.Random.Range(1, sides + 1);
        }

        /// <summary>
        /// Roll a die described in a string.
        /// </summary>
        /// <param name="str">Example: "1d6"; for a 1 dice of 6 sides.</param>
        /// <returns></returns>
        public static int RollDieFromString(string str)
        {
            return ParseDiceNotation(str);
        }

        /// <summary>
        /// For multiple dice in a string.
        /// </summary>
        /// <param name="str">Example: "1d6,2d4"</param>
        /// <param name="separator">,</param>
        /// <returns></returns>
        public static int RollDiceFromString(string str, string separator = ",")
        {
            var diceNotations = str.Split(separator);
            return diceNotations.Sum(ParseDiceNotation);
        }

        private static int ParseDiceNotation(string diceNotation)
        {
            // Regex pattern to match XdY format where X and Y are numbers
            const string pattern = @"^(\d+)d(\d+)$";
            var match = Regex.Match(diceNotation, pattern);

            if (!match.Success)
            {
                DebugUtils.DebugLogErrorMsg($"Invalid dice notation: {diceNotation}!");
                return 0;
            }

            var count = int.Parse(match.Groups[1].Value);
            var sides = int.Parse(match.Groups[2].Value);

            var result = 0;
            for (var i = 0; i < count; i++)
            {
                result += RollDie(sides);
            }

            return result;
        }

        public static bool VerifyDiceNotation(string diceNotation)
        {
            const string pattern = @"^(\d+)d(\d+)$";
            var match = Regex.Match(diceNotation, pattern);
            return match.Success;
        }
    }
}