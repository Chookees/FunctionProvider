namespace FunctionProvider.Various
{
    public sealed class GUID
    {
        #region Lazy initialization

        private static readonly Lazy<GUID> lazy = new Lazy<GUID>(() => new GUID());

        public static GUID Task { get { return lazy.Value; } }

        private GUID() { }

        #endregion

        /// <summary>
        /// Generates a new GUID.
        /// </summary>
        /// <returns>New GUID.</returns>
        public Guid Generate()
        {
            return new Guid();
        }

        /// <summary>
        /// Conmverts a string to a parsed Guid.
        /// </summary>
        /// <param name="guid">guid as string.</param>
        /// <returns>Parsed GUID on success else Guid.Empty.</returns>
        public Guid ParseToGuid(string guid)
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
        public string ParseToString(Guid guid)
        {
            return guid.ToString();
        }

        /// <summary>
        /// Gets the hashcode of a guid.
        /// </summary>
        /// <param name="guid">Guid to extract the hashcode from.</param>
        /// <returns>Hashcode as int.</returns>
        public int GetHashcode(Guid guid)
        {
            return guid.GetHashCode();
        }

        /// <summary>
        /// Validates if the input string is a valid GUID.
        /// </summary>
        /// <param name="guid">The GUID to validate.</param>
        /// <returns>True if the GUID is valid, otherwise false.</returns>
        public bool IsValidGuid(string guid)
        {
            return Guid.TryParse(guid, out _);
        }
    }
}
