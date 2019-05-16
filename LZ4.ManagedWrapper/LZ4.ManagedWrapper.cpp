
#include "stdafx.h"

#include "lz4.h"
#include "lz4hc.h"

#include "LZ4.ManagedWrapper.h"

using namespace System::Runtime::InteropServices;

//* Wraps the LZ4 compression method 'LZ4_compress_default' */
array<unsigned char>^ LZ4ManagedWrapper::LZ4Wrapper::CompressDefault(array<unsigned char>^ dataToCompress)
{
	// Get access to the managed data so we can access it as native data
	pin_ptr<unsigned char> nativeDataToCompress = &dataToCompress[0];

	// Calculate the largest possible size for the destination.
	const auto maxDestinationSize = LZ4_compressBound(dataToCompress->Length);
	if (maxDestinationSize <= 0)
	{
		return gcnew array<unsigned char>(0);
	}

	// Create a destination buffer to write too
	auto nativeDestination = new char[maxDestinationSize];

	// Call the LZ4 compression method
	const auto actualDestinationSize = LZ4_compress_default((const char*)nativeDataToCompress, nativeDestination, dataToCompress->Length, maxDestinationSize);

	// Create a managed array for our compressed data.
	// The LZ4 compression method returns the actual size of the compressed data so we can create
	// a managed buffer of the correct size.
	array<unsigned char>^ compressedData = gcnew array<unsigned char>(actualDestinationSize);	

	// Copy the native data across into the managed array
	Marshal::Copy(IntPtr(nativeDestination), compressedData, 0, actualDestinationSize);

	// Destroy the native buffer
	delete[] nativeDestination;

	// Return the compressed data
	return compressedData;
}

//* Wraps the LZ4 compression method 'LZ4_compress_HC' */
array<unsigned char>^ LZ4ManagedWrapper::LZ4Wrapper::CompressHighQuality(array<unsigned char>^ dataToCompress, int compressionLevel)
{
	// Get access to the managed data so we can access it as native data
	pin_ptr<unsigned char> nativeDataToCompress = &dataToCompress[0];

	// Calculate the largest possible size for the destination.
	const auto maxDestinationSize = LZ4_compressBound(dataToCompress->Length);
	if (maxDestinationSize <= 0)
	{
		return gcnew array<unsigned char>(0);
	}

	// Create a destination buffer to write too
	auto nativeDestination = new char[dataToCompress->Length];

	// Call the LZ4 compression method
	const auto actualDestinationSize = LZ4_compress_HC((const char*)nativeDataToCompress, nativeDestination, dataToCompress->Length, dataToCompress->Length, compressionLevel);

	// Create a managed array for our compressed data.
	// The LZ4 compression method returns the actual size of the compressed data so we can create
	// a managed buffer of the correct size.
	array<unsigned char>^ compressedData = gcnew array<unsigned char>(actualDestinationSize);

	// Copy the native data across into the managed array
	Marshal::Copy(IntPtr(nativeDestination), compressedData, 0, actualDestinationSize);

	// Destroy the native buffer
	delete[] nativeDestination;

	// Return the compressed data
	return compressedData;
}

//* Wraps the LZ4 decompression method 'LZ4_decompress_safe' */
array<unsigned char>^ LZ4ManagedWrapper::LZ4Wrapper::DecompressSafe(array<unsigned char>^ dataToDecompress, int uncompressedSize)
{
	// Get access to the managed data so we can access it as native data
	pin_ptr<unsigned char> nativeDataToDecompress = &dataToDecompress[0];

	// Create a target buffer for the decompressed data
	auto nativeDestination = new char[uncompressedSize];

	// Call the LZ4 compression method
	const auto decompressedSize = LZ4_decompress_safe((const char*)nativeDataToDecompress, nativeDestination, dataToDecompress->Length, uncompressedSize);

	// Check to see if the data is valid and can be decompressed.
	if (decompressedSize <= 0)
	{
		// The data is invalid and can not be decompressed.
		delete[] nativeDestination;
		return nullptr;
	}

	// Create a managed array for our decompressed data.
	// The LZ4 compression method returns the actual size of the decompressed data so we can create
	// a managed buffer of the correct size.
	array<unsigned char>^ decompressedData = gcnew array<unsigned char>(decompressedSize);

	// Copy the native data across into the managed array
	Marshal::Copy(IntPtr(nativeDestination), decompressedData, 0, decompressedSize);

	// Destroy the native buffer
	delete[] nativeDestination;

	return decompressedData;
}
