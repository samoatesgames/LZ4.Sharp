// LZ4.ManagedWrapper.h

#pragma once

using namespace System;

namespace LZ4ManagedWrapper {

	public ref class LZ4Wrapper
	{
	public:
		static array<unsigned char>^ CompressDefault(array<unsigned char>^ dataToCompress, int compressionLevel);
		static array<unsigned char>^ CompressHighQuality(array<unsigned char>^ dataToCompress, int compressionLevel);
	};
}
