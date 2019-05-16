using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LZ4.Sharp.Tests
{
    [TestClass]
    public class LZ4SharpFastCompressionTests
    {
        /// <summary>
        /// Given some valid data test we can use LZ4 fast compression.
        /// Check that we successfully compress and that the compressed data is
        /// smaller or the same size as the source data.
        /// </summary>
        [TestMethod]
        public void TestFastCompressionSuccess()
        {
            var validTestData = TestHelper.GetDataToCompress();
            var result = LZ4Sharp.CompressBytes(validTestData, out var compressedData, LZ4CompressionSettings.Fast);
            Assert.AreEqual(LZ4Result.Success, result);
            Assert.IsTrue(validTestData.Length >= compressedData.Length);
        }

        /// <summary>
        /// Attempt to compress using fast compression, but with a non-default compression level.
        /// The result should be 'FastCompressionOnlySupportsDefaultCompressionLevel' and the compressed
        /// data should be null.
        /// </summary>
        [TestMethod]
        public void TestFastCompressionNonDefaultLevelFail()
        {
            var validTestData = TestHelper.GetDataToCompress();
            var result = LZ4Sharp.CompressBytes(validTestData, out var compressedData, new LZ4CompressionSettings(LZ4CompressionMode.Fast, LZ4CompressionLevel.Max));
            Assert.AreEqual(LZ4Result.FastCompressionOnlySupportsDefaultCompressionLevel, result);
            Assert.IsNull(compressedData);
        }

        /// <summary>
        /// Given some data which can't be compressed, check that compression fails.
        /// The result should be 'CompressionFailed' and the compressed data should
        /// be null.
        /// </summary>
        [TestMethod]
        public void TestFastCompressionBadDataFail()
        {
            var invalidData = TestHelper.CreateInvalidLongData();
            var result = LZ4Sharp.CompressBytes(invalidData, out var compressedData, LZ4CompressionSettings.Fast);
            Assert.AreEqual(LZ4Result.CompressionFailed, result);
            Assert.IsNull(compressedData);
        }

        /// <summary>
        /// Check that passing invalid arguments is handled correctly.
        /// </summary>
        [TestMethod]
        public void TestFastCompressionBadParameters()
        {
            var result = LZ4Sharp.CompressBytes(null, out var compressedData, LZ4CompressionSettings.Fast);
            Assert.AreEqual(LZ4Result.UncompressedDataIsNull, result);
            Assert.IsNull(compressedData);

            result = LZ4Sharp.CompressBytes(null, out compressedData, null);
            Assert.AreEqual(LZ4Result.UncompressedDataIsNull, result);
            Assert.IsNull(compressedData);

            result = LZ4Sharp.CompressBytes(TestHelper.GetDataToCompress(), out compressedData, null);
            Assert.AreEqual(LZ4Result.CompressionSettingsAreNull, result);
            Assert.IsNull(compressedData);

            result = LZ4Sharp.CompressBytes(TestHelper.CreateInvalidLongData(), out compressedData, null);
            Assert.AreEqual(LZ4Result.CompressionSettingsAreNull, result);
            Assert.IsNull(compressedData);

            result = LZ4Sharp.CompressBytes(TestHelper.GetDataToCompress(), out compressedData, new LZ4CompressionSettings((LZ4CompressionMode)3, LZ4CompressionLevel.Default));
            Assert.AreEqual(LZ4Result.UnsupportedCompressionMode, result);
            Assert.IsNull(compressedData);
        }
    }
}
