namespace FunctionProvider.Various
{
    public class GUID
    {
        /// <summary>
        /// Generates a new GUID.
        /// </summary>
        /// <returns>New GUID.</returns>
        public static Guid Generate()
        {
            return new Guid();
        }

        /// <summary>
        /// Conmverts a string to a parsed Guid.
        /// </summary>
        /// <param name="guid">guid as string.</param>
        /// <returns>Parsed GUID on success else Guid.Empty.</returns>
        public static Guid ParseToGuid(string guid)
        {
            if (string.IsNullOrEmpty(guid) || string.IsNullOrWhiteSpace(guid))
            {
                return Guid.Empty;
            }

            try
            {
                return Guid.Parse(guid);
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }

        /// <summary>
        /// Converts the Guid to a string.
        /// </summary>
        /// <param name="guid">guid as Guid.</param>
        /// <returns>Guid as string.</returns>
        public static string ParseToString(Guid guid)
        {
            return guid.ToString();
        }

        /// <summary>
        /// Gets the hashcode of a guid.
        /// </summary>
        /// <param name="guid">Guid to extract the hashcode from.</param>
        /// <returns>Hashcode as int.</returns>
        public static int GetHashcode(Guid guid)
        {
            return guid.GetHashCode();
        }
    }
}
