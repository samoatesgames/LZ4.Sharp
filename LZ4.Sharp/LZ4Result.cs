
namespace LZ4.Sharp
{
    public enum LZ4Result
    {
        /// <summary>
        /// The compression has completed successfully.
        /// </summary>
        Success,

        /// <summary>
        /// Compression failed, happens when LZ4 returns a zero length compresison result.
        /// </summary>
        CompressionFailed,

        /// <summary>
        /// The compression mode specified is not currently supported.
        /// </summary>
        UnsupportedCompressionMode,

        /// <summary>
        /// The compression level specified is not valid.
        /// </summary>
        InvalidCompressionLevel,

        /// <summary>
        /// When using the fast compression mode, on the 'Default' compression level is supported.
        /// </summary>
        FastCompressionOnlySupportsDefaultCompressionLevel,

        /// <summary>
        /// An unknown error has occured.
        /// </summary>
        UnknownError
    }
}
