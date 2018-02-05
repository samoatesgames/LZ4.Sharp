using System.IO;
using System.Text;

namespace LZ4.Sharp
{
    public static class LZ4Sharp
    {
        #region Compression Methods
        /// <summary>
        /// Compress a given array of bytes, storing the result within the 'out' variable 'compressedData'.
        /// The compression is completed respected the settings provided.
        /// </summary>
        /// <param name="data">The data you want to compress using LZ4.</param>
        /// <param name="compressedData">The compressed representation of the data, null if the result is not 'Success'.</param>
        /// <param name="settings">The settings to use when compressing the provided data.</param>
        /// <returns>An LZ4Result stating the result of the compression.</returns>
        public static LZ4Result CompressBytes(byte[] data, out byte[] compressedData, LZ4CompressionSettings settings)
        {
            // Validate input arguments
            if (data == null)
            {
                compressedData = null;
                return LZ4Result.UncompressedDataIsNull;
            }

            if (settings == null)
            {
                compressedData = null;
                return LZ4Result.CompressionSettingsAreNull;
            }

            // Validate the compression level
            if (settings.CompressionLevel > LZ4CompressionLevel.Max ||
                settings.CompressionLevel < LZ4CompressionLevel.Lowest)
            {
                compressedData = null;
                return LZ4Result.InvalidCompressionLevel;
            }

            // Attempt the compression
            switch (settings.CompressionMode)
            {
                case LZ4CompressionMode.Fast:
                {
                    if (settings.CompressionLevel != LZ4CompressionLevel.Default)
                    {
                        compressedData = null;
                        return LZ4Result.FastCompressionOnlySupportsDefaultCompressionLevel;
                    }

                    compressedData = LZ4ManagedWrapper.LZ4Wrapper.CompressDefault(data);
                    if (compressedData.Length == 0)
                    {
                        compressedData = null;
                        return LZ4Result.CompressionFailed;
                    }
                    break;
                }

                case LZ4CompressionMode.HighQuality:
                {
                    compressedData = LZ4ManagedWrapper.LZ4Wrapper.CompressHighQuality(data, (int)settings.CompressionLevel);
                    if (compressedData.Length == 0)
                    {
                        compressedData = null;
                        return LZ4Result.CompressionFailed;
                    }
                    break;
                }

                default:
                {
                    compressedData = null;
                    return LZ4Result.UnsupportedCompressionMode;
                }
            }

            // We always return if an error occurred, so if we get here we have succeeded.
            return LZ4Result.Success;
        }

        /// <summary>
        /// Compress a string, storing the result within the 'out' variable 'compressedData'.
        /// The compression is completed respected the settings provided.
        /// </summary>
        /// <param name="data">The string you want to compress using LZ4.</param>
        /// <param name="compressedData">The compressed representation of the data, null if the result is not 'Success'.</param>
        /// <param name="settings">The settings to use when compressing the provided data.</param>
        /// <returns>An LZ4Result stating the result of the compression.</returns>
        public static LZ4Result CompressString(string data, out byte[] compressedData, LZ4CompressionSettings settings)
        {
            return CompressBytes(Encoding.ASCII.GetBytes(data), out compressedData, settings);
        }

        /// <summary>
        /// Compress a given stream, storing the result within the 'out' variable 'compressedData'.
        /// The compression is completed respected the settings provided.
        /// </summary>
        /// <param name="stream">The stream you want to compress using LZ4.</param>
        /// <param name="compressedData">The compressed representation of the data, null if the result is not 'Success'.</param>
        /// <param name="settings">The settings to use when compressing the provided data.</param>
        /// <returns>An LZ4Result stating the result of the compression.</returns>
        public static LZ4Result CompressStream(Stream stream, out byte[] compressedData, LZ4CompressionSettings settings)
        {
            using (var tempStream = new MemoryStream())
            {
                stream.CopyTo(tempStream);
                return CompressBytes(tempStream.ToArray(), out compressedData, settings);
            }
        }
        #endregion
    }
}
