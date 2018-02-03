// This is the main DLL file.

#include "stdafx.h"

#include "lz4.h"
#include "lz4hc.h"
#include "LZ4.ManagedWrapper.h"

using namespace System::Runtime::InteropServices;

array<unsigned char>^ LZ4ManagedWrapper::LZ4Wrapper::CompressDefault(array<unsigned char>^ dataToCompress, int compressionLevel)
{
	auto nativeSource = new char[dataToCompress->Length];
	auto nativeDestination = new char[dataToCompress->Length];

	Marshal::Copy(dataToCompress, 0, IntPtr(nativeSource), dataToCompress->Length);

	const auto actualDestinationSize = LZ4_compress_default(nativeSource, nativeDestination, dataToCompress->Length, dataToCompress->Length);

	array<unsigned char>^ compressedData = gcnew array<unsigned char>(actualDestinationSize);	
	Marshal::Copy(IntPtr(nativeDestination), compressedData, 0, actualDestinationSize);

	delete[] nativeSource;
	delete[] nativeDestination;

	return compressedData;
}

array<unsigned char>^ LZ4ManagedWrapper::LZ4Wrapper::CompressHighQuality(array<unsigned char>^ dataToCompress, int compressionLevel)
{
	auto nativeSource = new char[dataToCompress->Length];
	auto nativeDestination = new char[dataToCompress->Length];

	Marshal::Copy(dataToCompress, 0, IntPtr(nativeSource), dataToCompress->Length);

	const auto actualDestinationSize = LZ4_compress_HC(nativeSource, nativeDestination, dataToCompress->Length, dataToCompress->Length, compressionLevel);

	array<unsigned char>^ compressedData = gcnew array<unsigned char>(actualDestinationSize);
	Marshal::Copy(IntPtr(nativeDestination), compressedData, 0, actualDestinationSize);

	delete[] nativeSource;
	delete[] nativeDestination;

	return compressedData;
}
