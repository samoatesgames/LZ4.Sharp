
using System.IO;
using System.Text;

namespace LZ4.Sharp
{
    public class LZ4Sharp
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="compressedData"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static LZ4Result CompressBytes(byte[] data, out byte[] compressedData, LZ4CompressionSettings settings)
        {
            compressedData = null;

            switch (settings.CompressionMode)
            {
                case LZ4CompressionMode.Fast:
                {
                    compressedData = LZ4ManagedWrapper.LZ4Wrapper.CompressDefault(data, (int)settings.CompressionLevel);
                    if (compressedData.Length == 0)
                    {
                        return LZ4Result.UnknownError;
                    }
                    break;
                }

                case LZ4CompressionMode.HighQuality:
                {
                        compressedData = LZ4ManagedWrapper.LZ4Wrapper.CompressHighQuality(data, (int)settings.CompressionLevel);
                        if (compressedData.Length == 0)
                        {
                            return LZ4Result.UnknownError;
                        }
                        break;
                    }
            }

            return LZ4Result.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="compressedData"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static LZ4Result CompressString(string data, out byte[] compressedData, LZ4CompressionSettings settings)
        {
            return CompressBytes(Encoding.ASCII.GetBytes(data), out compressedData, settings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="compressedData"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static LZ4Result CompressStream(Stream stream, out byte[] compressedData, LZ4CompressionSettings settings)
        {
            using (var tempStream = new MemoryStream())
            {
                stream.CopyTo(tempStream);
                return CompressBytes(tempStream.ToArray(), out compressedData, settings);
            }
        }
    }
}
