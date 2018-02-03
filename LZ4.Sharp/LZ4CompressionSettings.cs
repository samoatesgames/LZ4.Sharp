
namespace LZ4.Sharp
{
    /// <summary>
    /// 
    /// </summary>
    public class LZ4CompressionSettings
    {
        /// <summary>
        /// 
        /// </summary>
        public LZ4CompressionMode CompressionMode { get; }

        /// <summary>
        /// 
        /// </summary>
        public LZ4CompressionLevel CompressionLevel { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="level"></param>
        public LZ4CompressionSettings(LZ4CompressionMode mode, LZ4CompressionLevel level)
        {
            CompressionMode = mode;
            CompressionLevel = level;
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly LZ4CompressionSettings Fast = new LZ4CompressionSettings(LZ4CompressionMode.Fast, LZ4CompressionLevel.Default);

        /// <summary>
        /// 
        /// </summary>
        public static readonly LZ4CompressionSettings Default = new LZ4CompressionSettings(LZ4CompressionMode.HighQuality, LZ4CompressionLevel.Default);

        /// <summary>
        /// 
        /// </summary>
        public static readonly LZ4CompressionSettings Ultra = new LZ4CompressionSettings(LZ4CompressionMode.HighQuality, LZ4CompressionLevel.Max);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Mode: {CompressionMode}, Level: {CompressionLevel}";
        }
    }

    public enum LZ4CompressionMode
    {
        Fast,
        HighQuality
    }

    /// <summary>
    /// 
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
