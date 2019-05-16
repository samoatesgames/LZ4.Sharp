using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LZ4.Sharp.Tests
{
    [TestClass]
    public class LZ4SharpDecompressionTests
    {
        /// <summary>
        /// Test to see if a block of pre-compressed data is correctly
        /// decompressed and equal to the originally uncompressed data.
        /// </summary>
        [TestMethod]
        public void TestDecompressionOfCompressedData()
        {
            var uncompressedData = TestHelper.GetDataToCompress();
            var compressedData = TestHelper.GetCompressedData();
            var decompressionResult = LZ4Sharp.DecompressBytes(compressedData, uncompressedData.Length, out var decompressedData);

            Assert.AreEqual(LZ4Result.Success, decompressionResult);
            Assert.AreEqual(uncompressedData.Length, decompressedData.Length);
            Assert.IsTrue(uncompressedData.SequenceEqual(decompressedData));
        }

        /// <summary>
        /// Check the decompressing some random bytes fails.
        /// </summary>
        [TestMethod]
        public void TestDecompressionOfBadDataFails()
        {
            var compressedData = new byte[] { 1, 2, 3, 4, 5, 6 };
            var decompressionResult = LZ4Sharp.DecompressBytes(compressedData, 128, out var decompressedData);

            Assert.AreEqual(LZ4Result.DecompressionFailed, decompressionResult);
            Assert.IsNull(decompressedData);
        }

        /// <summary>
        /// Check the decompressing valid data, with an invalid uncompressed data size fails.
        /// </summary>
        [TestMethod]
        public void TestDecompressionOfInvalidSourceSizeFails()
        {
            var compressedData = TestHelper.GetCompressedData();
            var decompressionResult = LZ4Sharp.DecompressBytes(compressedData, 128, out var decompressedData);

            Assert.AreEqual(LZ4Result.DecompressionFailed, decompressionResult);
            Assert.IsNull(decompressedData);
        }
    }
}
