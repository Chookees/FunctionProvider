namespace FunctionProvider.Math
{
    using SM = System.Math;

    public class Basic
    {
        /// <summary>
        /// 3.14159265358979323846
        /// </summary>
        public static double Pi => SM.PI;

        /// <summary>
        /// 2.7182818284590452354
        /// </summary>
        public static double E => SM.E;

        /// <summary>
        /// Rounds a decimal to two.
        /// </summary>
        /// <param name="numberToRound">Number to be rounded.</param>
        /// <returns>Rounded number as decimal.</returns>
        public static decimal RoundingToTwo(decimal numberToRound)
        {
            return SM.Round(numberToRound, 2);
        }
    }
}
