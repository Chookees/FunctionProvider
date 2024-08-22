namespace FunctionProvider.Math
{
    using SM = System.Math;

    public class Basic
    {
        /// <summary>
        /// 3.14159265358979323846
        /// </summary>
        public static double Pi => 3.14159265358979323846;

        /// <summary>
        /// 2.7182818284590452354
        /// </summary>
        public static double E => 2.7182818284590452354;

        /// <summary>
        /// Rounds a decimal to two numbers after comma.
        /// </summary>
        /// <param name="numberToRound">Number to be rounded.</param>
        /// <returns>Rounded number as decimal.</returns>
        public static decimal RoundingToTwo(decimal numberToRound)
        {
            return SM.Round(numberToRound, 2);
        }

        /// <summary>
        /// Rounds a double to two numbers after comma.
        /// </summary>
        /// <param name="numberToRound">Number to be rounded.</param>
        /// <returns>Rounded number as double.</returns>
        public static double RoundingToTwo(double numberToRound)
        {
            return SM.Round(numberToRound, 2);
        }

        /// <summary>
        /// Returns number to the power of powerOf.
        /// </summary>
        /// <param name="number">Number.</param>
        /// <param name="powerOf">Power to.</param>
        /// <returns>Number with the power of powerOf as double.</returns>
        public static double Pow(double number, double powerOf)
        {
            return SM.Pow(number, powerOf);
        }

        /// <summary>
        /// Returns the Squareroot of a given number.
        /// </summary>
        /// <param name="number">Number to extract the squareroot of.</param>
        /// <returns>Squareroot of number as double.</returns>
        public static double Sqrt(double number)
        {
            return SM.Sqrt(number);
        }

        /// <summary>
        /// Calculates the standard deviation.
        /// </summary>
        /// <param name="values">Double Array of values.</param>
        /// <returns>The Standard Deviation as double.</returns>
        public static double CalculateStandardDeviation(double[] values)
        {
            double mean = values.Average();
            double sumOfSquares = values.Select(val => (val - mean) * (val - mean)).Sum();
            return SM.Sqrt(sumOfSquares / values.Length);
        }
    }
}
