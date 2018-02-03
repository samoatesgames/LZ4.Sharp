
namespace LZ4.Sharp
{
    /// <summary>
    /// Compression settings to use whilst compressing data using LZ4
    /// </summary>
    public class LZ4CompressionSettings
    {
        /// <summary>
        /// The compression mode which should be used.
        /// </summary>
        public LZ4CompressionMode CompressionMode { get; }

        /// <summary>
        /// The compression level which should be used.
        /// </summary>
        public LZ4CompressionLevel CompressionLevel { get; }

        /// <summary>
        /// Create a compression settings object with the specified settings.
        /// </summary>
        /// <param name="mode">The compression mode which should be used.</param>
        /// <param name="level">The compression level which should be used.</param>
        public LZ4CompressionSettings(LZ4CompressionMode mode, LZ4CompressionLevel level)
        {
            CompressionMode = mode;
            CompressionLevel = level;
        }

        /// <summary>
        /// Default settings for 'Fast' LZ4 compression using 'LZ4_compress_default'
        /// </summary>
        public static readonly LZ4CompressionSettings Fast = new LZ4CompressionSettings(LZ4CompressionMode.Fast, LZ4CompressionLevel.Default);

        /// <summary>
        /// Default settings for 'High Quality' LZ4 compression using 'LZ4_compress_HC'.
        /// </summary>
        public static readonly LZ4CompressionSettings Default = new LZ4CompressionSettings(LZ4CompressionMode.HighQuality, LZ4CompressionLevel.Default);

        /// <summary>
        /// Ultra settings for 'High Quality' LZ4 compression using 'LZ4_compress_HC'.
        /// </summary>
        public static readonly LZ4CompressionSettings Ultra = new LZ4CompressionSettings(LZ4CompressionMode.HighQuality, LZ4CompressionLevel.Max);

        /// <summary>
        /// Output the mode and level of the settings as a user friendly string.
        /// </summary>
        /// <returns>A string representing the compression settings.</returns>
        public override string ToString()
        {
            return $"Mode: {CompressionMode}, Level: {CompressionLevel}";
        }
    }

    /// <summary>
    /// Currently supported compression modes.
    /// </summary>
    public enum LZ4CompressionMode
    {
        /// <summary>
        /// Uses the LZ4 method 'LZ4_compress_default'
        /// https://github.com/lz4/lz4/blob/e3f73fa6a6865ca3828a810dc9e45ff616d44681/lib/lz4.h#L139
        /// </summary>
        Fast,

        /// <summary>
        /// Uses the LZ4 method 'LZ4_compress_HC'
        /// https://github.com/lz4/lz4/blob/e3f73fa6a6865ca3828a810dc9e45ff616d44681/lib/lz4hc.h#L66
        /// </summary>
        HighQuality
    }

    /// <summary>
    /// Supported compression levels.
    /// These are only respected when using the 'HighQuality' compression mode.
    /// https://github.com/lz4/lz4/blob/e3f73fa6a6865ca3828a810dc9e45ff616d44681/lib/lz4hc.h#L47
    /// </summary>
    public enum LZ4CompressionLevel
    {
        Lowest = 3,
        VeryLow = 4,
        Lower = 5,
        Low = 6,
        Medium = 7,
        BelowAverage = 8,
        Default = 9,
        AboveAverage = 10,
        High = 11,
        Max = 12
    }
}
