# LZ4.Sharp

## About

A C# wrapper for LZ4, supporting multiple compression modes and decompression of data.

[![GitHub](https://img.shields.io/github/license/samoatesgames/LZ4.Sharp.svg?style=flat-square)](https://github.com/samoatesgames/LZ4.Sharp/blob/master/LICENSE)
[![Nuget](https://img.shields.io/nuget/dt/LZ4.Sharp.svg?label=Nuget&style=flat-square)](https://www.nuget.org/packages/LZ4.Sharp/)

### Methods

```csharp
/// <summary>
/// Compress a given array of bytes, storing the result within the 'out' variable 'compressedData'.
/// The compression is completed respected the settings provided.
/// </summary>
/// <param name="data">The data you want to compress using LZ4.</param>
/// <param name="compressedData">The compressed representation of the data, null if the result is not 'Success'.</param>
/// <param name="settings">The settings to use when compressing the provided data.</param>
/// <returns>An LZ4Result stating the result of the compression.</returns>
public static LZ4Result CompressBytes(byte[] data, out byte[] compressedData, LZ4CompressionSettings settings)
```

```csharp
/// <summary>
/// Compress a string, storing the result within the 'out' variable 'compressedData'.
/// The compression is completed respected the settings provided.
/// </summary>
/// <param name="data">The string you want to compress using LZ4.</param>
/// <param name="compressedData">The compressed representation of the data, null if the result is not 'Success'.</param>
/// <param name="settings">The settings to use when compressing the provided data.</param>
/// <returns>An LZ4Result stating the result of the compression.</returns>
public static LZ4Result CompressString(string data, out byte[] compressedData, LZ4CompressionSettings settings)
```

```csharp
/// <summary>
/// Compress a given stream, storing the result within the 'out' variable 'compressedData'.
/// The compression is completed respected the settings provided.
/// </summary>
/// <param name="stream">The stream you want to compress using LZ4.</param>
/// <param name="compressedData">The compressed representation of the data, null if the result is not 'Success'.</param>
/// <param name="settings">The settings to use when compressing the provided data.</param>
/// <returns>An LZ4Result stating the result of the compression.</returns>
public static LZ4Result CompressStream(Stream stream, out byte[] compressedData, LZ4CompressionSettings settings)
```

```csharp
/// <summary>
/// Decompress an array of compressed data, storing the result within the 'out' variable 'data'.
/// </summary>
/// <param name="compressedData">The source compressed data to be decompressed.</param>
/// <param name="uncompressedDataSize">The expected size of the decompressed data.</param>
/// <param name="data">[out] If decompression is successful the decompressed data, else null.</param>
/// <returns>An LZ4Result stating the result of the decompression.</returns>
public static LZ4Result DecompressBytes(byte[] compressedData, int uncompressedDataSize, out byte[] data)
```

```csharp
/// <summary>
/// Decompress a stream of compressed data, storing the result within the 'out' variable 'data'.
/// </summary>
/// <param name="compressedData">The source compressed data to be decompressed.</param>
/// <param name="uncompressedDataSize">The expected size of the decompressed data.</param>
/// <param name="data">[out] If decompression is successful the decompressed data, else null.</param>
/// <returns>An LZ4Result stating the result of the decompression.</returns>
```

## Example

```csharp
const int randomDataSize = 1024 * 512;
var dataToCompress = new byte[randomDataSize];

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
```

```csharp
// Output:
/*
Compressed 524288 bytes down to 296705 bytes using settings Mode: Fast, Level: Default [Time 00:00:00.2922018].
Compressed 524288 bytes down to 207683 bytes using settings Mode: HighQuality, Level: Default [Time 00:00:03.9848956].
Compressed 524288 bytes down to 195994 bytes using settings Mode: HighQuality, Level: Max [Time 00:00:03.4059679].
*/
```
