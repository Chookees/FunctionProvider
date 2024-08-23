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

        /// <summary>
        /// Calculates the n-th Fibonacci number recursive.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Fibonacci(int number)
        {
            if (number <= 1) return number;
            return Fibonacci(number - 1) + Fibonacci(number - 2);
        }

        /// <summary>
        /// Calculates the determinant of a 3x3 matrix.
        /// </summary>
        /// <param name="matrix">A 3x3 matrix represented as a 2D array.</param>
        /// <returns>-0 when invalid input, else the determinant of the matrix.</returns>
        public static double Determinant(double[,] matrix)
        {
            if (matrix.GetLength(0) != 3 || matrix.GetLength(1) != 3)
            {
                return -0;
            }

            return matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1])
                 - matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0])
                 + matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);
        }
    }
}
