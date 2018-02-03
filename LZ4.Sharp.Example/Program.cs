using System;

namespace LZ4.Sharp.Example
{
    class Program
    {
        static void Main()
        {
            const int randomDataSize = 1024 * 512; // 512KB
            byte[] dataToCompress = new byte[randomDataSize];

            // Generate some random data for our data source
            var random = new Random();
            for (var offset = 0; offset < randomDataSize; ++offset)
            {
                dataToCompress[offset] = (byte)random.Next('A', 'E');
            }

            foreach (var compressionSetting in new[]
                {
                    LZ4CompressionSettings.Fast,
                    LZ4CompressionSettings.Default,
                    LZ4CompressionSettings.Ultra
                })
            {
                var start = DateTime.Now;
                // Compress the data
                var result = LZ4Sharp.CompressBytes(dataToCompress, out var compressedData, compressionSetting);
                if (result != LZ4Result.Success)
                {
                    Console.WriteLine($"Failed to compress data using settings {compressionSetting}, Reason: {result}.");
                    continue;
                }

                // Output the results
                var length = DateTime.Now - start;
                Console.WriteLine($"Compressed {dataToCompress.Length} bytes down to {compressedData.Length} bytes using settings {compressionSetting} [Time {length}].");
            }

            Console.WriteLine();
            Console.WriteLine("Complete");
            Console.ReadLine();
        }
    }
}
