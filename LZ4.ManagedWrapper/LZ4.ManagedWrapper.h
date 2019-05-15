// LZ4.ManagedWrapper.h

#pragma once

using namespace System;

namespace LZ4ManagedWrapper 
{
	public ref class LZ4Wrapper
	{
	public:
		//* Wraps the LZ4 compression method 'LZ4_compress_default' */
		static array<unsigned char>^ CompressDefault(array<unsigned char>^ dataToCompress);

		//* Wraps the LZ4 compression method 'LZ4_compress_HC' */
		static array<unsigned char>^ CompressHighQuality(array<unsigned char>^ dataToCompress, int compressionLevel);

		//* Wraps the LZ4 decompression method 'LZ4_decompress_safe' */
		static array<unsigned char>^ DecompressSafe(array<unsigned char>^ dataToDecompress, int uncompressedSize);
	};
}
