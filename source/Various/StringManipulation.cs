using System.IO.Compression;
using System.Text;

namespace FunctionProvider.Various
{


    public class StringManipulation
    {
        /// <summary>
        /// Converts a string to CamelCase format.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The CamelCase formatted string.</returns>
        public static string ToCamelCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string[] words = input.Split(new[] { ' ', '-', '_' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1).ToLower();
            }
            return string.Join("", words);
        }

        /// <summary>
        /// Compresses a string using GZip compression.
        /// </summary>
        /// <param name="text">The input string to compress.</param>
        /// <returns>The compressed byte array.</returns>
        public static byte[] CompressString(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            using (MemoryStream ms = new MemoryStream())
            {
                using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
                {
                    zip.Write(buffer, 0, buffer.Length);
                }
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Decompresses a byte array to a string using GZip compression.
        /// </summary>
        /// <param name="compressedText">The compressed byte array.</param>
        /// <returns>The decompressed string.</returns>
        public static string DecompressString(byte[] compressedText)
        {
            using (MemoryStream ms = new MemoryStream(compressedText))
            {
                using (GZipStream zip = new GZipStream(ms, CompressionMode.Decompress))
                {
                    using (StreamReader reader = new StreamReader(zip, Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        /// <summary>
        /// Converts a string to a dictionary of word frequencies.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>A dictionary with words as keys and their frequencies as values.</returns>
        public static Dictionary<string, int> WordFrequency(string input)
        {
            var wordFrequency = new Dictionary<string, int>();
            string[] words = input.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                string lowerWord = word.ToLower();
                if (wordFrequency.ContainsKey(lowerWord))
                {
                    wordFrequency[lowerWord]++;
                }
                else
                {
                    wordFrequency[lowerWord] = 1;
                }
            }
            return wordFrequency;
        }

        /// <summary>
        /// Finds all palindromes in a given text.
        /// </summary>
        /// <param name="text">The input text.</param>
        /// <returns>An array of palindromic words.</returns>
        public static string[] FindPalindromes(string text)
        {
            var words = text.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Where(word => word.SequenceEqual(word.Reverse())).ToArray();
        }

        /// <summary>
        /// Encrypts a text using the Caesar cipher method.
        /// </summary>
        /// <param name="text">The input text.</param>
        /// <param name="shift">The number of positions to shift each character.</param>
        /// <returns>The encrypted text.</returns>
        public static string CaesarCipher(string text, int shift)
        {
            return new string(text.Select(c =>
            {
                if (!char.IsLetter(c)) return c;
                char offset = char.IsUpper(c) ? 'A' : 'a';
                return (char)(((c + shift - offset) % 26) + offset);
            }).ToArray());
        }
    }
}
