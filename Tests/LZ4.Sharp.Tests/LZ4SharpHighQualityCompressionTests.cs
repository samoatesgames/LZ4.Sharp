using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LZ4.Sharp.Tests
{
    [TestClass]
    public class LZ4SharpHighQualityCompressionTests
    {
        /// <summary>
        /// Test that given some valid data, high quality compression succeeds.
        /// Testing both default and ultra settings, validating that data compressed
        /// using ultra settings is smaller than data compressed with the default.
        /// </summary>
        [TestMethod]
        public void TestHQCompressionSuccess()
        {
            var validTestData = TestHelper.CreateValidTestData();
            var result = LZ4Sharp.CompressBytes(validTestData, out var defaultCompressedData,
                LZ4CompressionSettings.Default);
            Assert.AreEqual(LZ4Result.Success, result);
            Assert.IsTrue(validTestData.Length >= defaultCompressedData.Length);

            result = LZ4Sharp.CompressBytes(validTestData, out var maxCompressedData, LZ4CompressionSettings.Ultra);
            Assert.AreEqual(LZ4Result.Success, result);
            Assert.IsTrue(validTestData.Length >= maxCompressedData.Length);

            Assert.IsTrue(defaultCompressedData.Length >= maxCompressedData.Length);
        }

        /// <summary>
        /// Given some data which can't be compressed, check that compression fails.
        /// The result should be 'CompressionFailed' and the compressed data should
        /// be null.
        /// </summary>
        [TestMethod]
        public void TestHQCompressionBadDataFail()
        {
            var invalidData = TestHelper.CreateInvalidLongData();
            var result = LZ4Sharp.CompressBytes(invalidData, out var compressedData, LZ4CompressionSettings.Default);
            Assert.AreEqual(LZ4Result.CompressionFailed, result);
            Assert.IsNull(compressedData);
        }

        /// <summary>
        /// Check that passing invalid arguments is handled correctly.
        /// </summary>
        [TestMethod]
        public void TestHQCompressionBadParameters()
        {
            var result = LZ4Sharp.CompressBytes(null, out var compressedData, LZ4CompressionSettings.Default);
            Assert.AreEqual(LZ4Result.UncompressedDataIsNull, result);
            Assert.IsNull(compressedData);

            result = LZ4Sharp.CompressBytes(null, out compressedData, null);
            Assert.AreEqual(LZ4Result.UncompressedDataIsNull, result);
            Assert.IsNull(compressedData);

            result = LZ4Sharp.CompressBytes(TestHelper.CreateValidTestData(), out compressedData, null);
            Assert.AreEqual(LZ4Result.CompressionSettingsAreNull, result);
            Assert.IsNull(compressedData);

            result = LZ4Sharp.CompressBytes(TestHelper.CreateInvalidLongData(), out compressedData, null);
            Assert.AreEqual(LZ4Result.CompressionSettingsAreNull, result);
            Assert.IsNull(compressedData);

            result = LZ4Sharp.CompressBytes(TestHelper.CreateValidTestData(), out compressedData, new LZ4CompressionSettings((LZ4CompressionMode)999, LZ4CompressionLevel.Default));
            Assert.AreEqual(LZ4Result.UnsupportedCompressionMode, result);
            Assert.IsNull(compressedData);

            result = LZ4Sharp.CompressBytes(TestHelper.CreateValidTestData(), out compressedData, new LZ4CompressionSettings(LZ4CompressionMode.HighQuality, (LZ4CompressionLevel)999));
            Assert.AreEqual(LZ4Result.InvalidCompressionLevel, result);
            Assert.IsNull(compressedData);
        }
    }
}
