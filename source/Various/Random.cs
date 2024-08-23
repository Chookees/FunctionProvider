namespace FunctionProvider.Various
{
    using System.Security.Cryptography;
    using SR = System.Random;

    public class Random
    {

        private static readonly SR _random = new SR();

        /// <summary>
        /// Generates a random integer between the specified minimum and maximum values.
        /// </summary>
        /// <param name="min">The inclusive lower bound.</param>
        /// <param name="max">The inclusive upper bound.</param>
        /// <returns>A random integer between min and max.</returns>
        public static int GenerateRandomInt(int min, int max)
        {
            return _random.Next(min, max + 1);
        }

        /// <summary>
        /// Generates a random string of the specified length.
        /// </summary>
        /// <param name="length">The length of the random string.</param>
        /// <returns>A random string of the specified length.</returns>
        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Generates a random double between 0.0 and 1.0.
        /// </summary>
        /// <returns>A random double between 0.0 and 1.0.</returns>
        public static double GenerateRandomDouble()
        {
            return _random.NextDouble();
        }

        /// <summary>
        /// Shuffles an array of integers.
        /// </summary>
        /// <param name="array">The array to shuffle.</param>
        public static void ShuffleArray(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        /// <summary>
        /// Generates a cryptographically secure random string of the specified length.
        /// </summary>
        /// <param name="length">The length of the random string.</param>
        /// <returns>A cryptographically secure random string of the specified length.</returns>
        public static string GenerateSecureRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            using (var crypto = new RNGCryptoServiceProvider())
            {
                var data = new byte[length];
                crypto.GetBytes(data);
                return new string(data.Select(b => chars[b % chars.Length]).ToArray());
            }
        }

        /// <summary>
        /// Generates a random permutation of a given array.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the array.</typeparam>
        /// <param name="array">The array to permute.</param>
        /// <returns>A random permutation of the array.</returns>
        public static T[] GenerateRandomPermutation<T>(T[] array)
        {
            var result = array.ToArray();
            for (int i = result.Length - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                var temp = result[i];
                result[i] = result[j];
                result[j] = temp;
            }
            return result;
        }

        /// <summary>
        /// Generates a random matrix with the specified dimensions and value range.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="columns">The number of columns in the matrix.</param>
        /// <param name="minValue">The minimum value for the matrix elements.</param>
        /// <param name="maxValue">The maximum value for the matrix elements.</param>
        /// <returns>A random matrix with the specified dimensions and value range.</returns>
        public static int[,] GenerateRandomMatrix(int rows, int columns, int minValue, int maxValue)
        {
            var matrix = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = _random.Next(minValue, maxValue + 1);
                }
            }
            return matrix;
        }

        /// <summary>
        /// Generates a random graph with the specified number of nodes and edges.
        /// </summary>
        /// <param name="nodes">The number of nodes in the graph.</param>
        /// <param name="edges">The number of edges in the graph.</param>
        /// <returns>A random graph represented as an adjacency list.</returns>
        public static Dictionary<int, List<int>> GenerateRandomGraph(int nodes, int edges)
        {
            var graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < edges; i++)
            {
                int node1 = _random.Next(nodes);
                int node2 = _random.Next(nodes);
                if (node1 != node2 && !graph[node1].Contains(node2))
                {
                    graph[node1].Add(node2);
                    graph[node2].Add(node1);
                }
            }

            return graph;
        }

        /// <summary>
        /// Generates a random password with the specified length and complexity.
        /// </summary>
        /// <param name="length">The length of the password.</param>
        /// <param name="includeSpecialChars">Whether to include special characters in the password.</param>
        /// <returns>A random password with the specified length and complexity.</returns>
        public static string GenerateRandomPassword(int length, bool includeSpecialChars)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            const string specialChars = "!@#$%^&*()_+[]{}|;:,.<>?";

            string charSet = chars + (includeSpecialChars ? specialChars : string.Empty);
            return new string(Enumerable.Repeat(charSet, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
