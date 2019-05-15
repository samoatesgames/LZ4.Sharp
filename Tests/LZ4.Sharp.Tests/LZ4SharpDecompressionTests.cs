using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LZ4.Sharp.Tests
{
    [TestClass]
    public class LZ4SharpDecompressionTests
    {
        /// <summary>
        /// Compress some data using fast compression.
        /// Then decompress the compressed data and validate the result is equal
        /// to the original input.
        /// </summary>
        [TestMethod]
        public void TestDecompressionOfFastCompressedData()
        {
            var input = TestHelper.CreateValidTestData();
            var compressionResult = LZ4Sharp.CompressBytes(input, out var compressedData, LZ4CompressionSettings.Fast);
            Assert.AreEqual(LZ4Result.Success, compressionResult);

            var decompressionResult = LZ4Sharp.DecompressBytes(compressedData, input.Length, out var decompressedData);
            Assert.AreEqual(LZ4Result.Success, decompressionResult);
            Assert.AreEqual(input.Length, decompressedData.Length);
            Assert.IsTrue(input.SequenceEqual(decompressedData));
        }

        /// <summary>
        /// Compress some data using ultra compression.
        /// Then decompress the compressed data and validate the result is equal
        /// to the original input.
        /// </summary>
        [TestMethod]
        public void TestDecompressionOfUltraCompressedData()
        {
            var input = TestHelper.CreateValidTestData();
            var compressionResult = LZ4Sharp.CompressBytes(input, out var compressedData, LZ4CompressionSettings.Ultra);
            Assert.AreEqual(LZ4Result.Success, compressionResult);

            var decompressionResult = LZ4Sharp.DecompressBytes(compressedData, input.Length, out var decompressedData);
            Assert.AreEqual(LZ4Result.Success, decompressionResult);
            Assert.AreEqual(input.Length, decompressedData.Length);
            Assert.IsTrue(input.SequenceEqual(decompressedData));
        }
    }
}
