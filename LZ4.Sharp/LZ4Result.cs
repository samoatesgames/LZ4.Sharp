
namespace LZ4.Sharp
{
    public enum LZ4Result
    {
        /// <summary>
        /// The compression has completed successfully.
        /// </summary>
        Success,

        /// <summary>
        /// Compression failed, happens when LZ4 returns a zero length compression result.
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
        /// The data set to be compressed is null.
        /// </summary>
        UncompressedDataIsNull,

        /// <summary>
        /// The specified compression settings are null.
        /// </summary>
        CompressionSettingsAreNull,

        /// <summary>
        /// An unknown error has occurred.
        /// </summary>
        UnknownError
    }
}
