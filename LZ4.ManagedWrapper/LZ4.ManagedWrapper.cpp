
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

	// Create a target buffer for the compressed data, compression can never make data larger so we know 
	// that the max buffer size is the size of the source data.
	auto nativeDestination = new char[dataToCompress->Length];

	// Call the LZ4 compression method
	const auto actualDestinationSize = LZ4_compress_default((const char*)nativeDataToCompress, nativeDestination, dataToCompress->Length, dataToCompress->Length);

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

	// Create a target buffer for the compressed data, compression can never make data larger so we know 
	// that the max buffer size is the size of the source data.
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
