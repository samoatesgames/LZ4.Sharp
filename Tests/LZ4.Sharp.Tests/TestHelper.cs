﻿
namespace LZ4.Sharp.Tests
{
    internal static class TestHelper
    {
        /// <summary>
        /// Create some data which can't be compressed because it exceeds
        /// the maximum length of data supported by LZ4.
        /// </summary>
        /// <returns></returns>
        public static byte[] CreateInvalidLongData()
        {
            var maxLength = 0x7E000000; // LZ4_MAX_INPUT_SIZE
            return new byte[maxLength + 1];
        }

        /// <summary>
        /// Create some valid data to compress.
        /// </summary>
        /// <returns></returns>
        public static byte[] GetDataToCompress()
        {
            return System.Text.Encoding.ASCII.GetBytes(
                "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAB" +
                "EAAAASCAMAAACKJ8VmAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZS" +
                "BJbWFnZVJlYWR5ccllPAAAA3FpVFh0WE1MOmNvbS5hZG9iZS" +
                "54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVz" +
                "VNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldG" +
                "EgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9Ik" +
                "Fkb2JlIFhNUCBDb3JlIDUuNS1jMDE0IDc5LjE1MTQ4MSwgMj" +
                "AxMy8wMy8xMy0xMjowOToxNSAgICAgICAgIj4gPHJkZjpSRE" +
                "YgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5Lz" +
                "AyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdG" +
                "lvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wTU09Imh0dHA6Ly" +
                "9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0Um" +
                "VmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cG" +
                "UvUmVzb3VyY2VSZWYjIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy" +
                "5hZG9iZS5jb20veGFwLzEuMC8iIHhtcE1NOk9yaWdpbmFsRG" +
                "9jdW1lbnRJRD0ieG1wLmRpZDpmYWFhOTdlYS03YTZkLTRhND" +
                "AtYjU5NC0xNWQ4NGIzNzM4M2EiIHhtcE1NOkRvY3VtZW50SU" +
                "Q9InhtcC5kaWQ6OUYwQzBFNjJGN0VBMTFFMzlFNjVGRTUxNE" +
                "I5Q0YwOEMiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6OU" +
                "YwQzBFNjFGN0VBMTFFMzlFNjVGRTUxNEI5Q0YwOEMiIHhtcD" +
                "pDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENDIChXaW" +
                "5kb3dzKSI+IDx4bXBNTTpEZXJpdmVkRnJvbSBzdFJlZjppbn" +
                "N0YW5jZUlEPSJ4bXAuaWlkOmQ1NTRhMWQ3LTY5ZTYtMzY0ZC" +
                "1hMjBkLTAyMDQwNzRlZWMwZCIgc3RSZWY6ZG9jdW1lbnRJRD" +
                "0ieG1wLmRpZDpmYWFhOTdlYS03YTZkLTRhNDAtYjU5NC0xNW" +
                "Q4NGIzNzM4M2EiLz4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcm" +
                "RmOlJERj4gPC94OnhtcG1ldGE+IDw/eHBhY2tldCBlbmQ9In" +
                "IiPz6djRRwAAAAMFBMVEXn9ftWxfO65PU0ufABoOuC0/YisO" +
                "UWs+9+ucwAre8AsvkTse0Are0Xsu7///8ArO2vlRf2AAAAhU" +
                "lEQVR42lyPCw7EIAhEEYe6ipX737agbtN2ogk8JnxItDykRc" +
                "i+Iv2A00k3f90ARBDEKuAgSVZdHiT2ehpjUEaQijw4gZ0wtq" +
                "eQl/0P+ZMzslDapM8e0eaeDpNt6YuY5kmiyyaHEBH75H7vDF" +
                "8NCyyPR/OAfVez+pQ1OtpbB/HvLboEGAAlDgycnkg61QAAAA" +
                "BJRU5ErkJggg==");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static byte[] GetCompressedData()
        {
            return new byte[]
            {
                240, 34, 100, 97, 116, 97, 58, 105, 109, 97,
                103, 101, 47, 112, 110, 103, 59, 98, 97, 115,
                101, 54, 52, 44, 105, 86, 66, 79, 82, 119,
                48, 75, 71, 103, 111, 65, 65, 65, 65, 78,
                83, 85, 104, 69, 85, 103, 65, 65, 65, 66,
                69, 16, 0, 208, 83, 67, 65, 77, 65, 65,
                65, 67, 75, 74, 56, 86, 109, 17, 0, 240,
                30, 71, 88, 82, 70, 87, 72, 82, 84, 98,
                50, 90, 48, 100, 50, 70, 121, 90, 81, 66,
                66, 90, 71, 57, 105, 90, 83, 66, 74, 98,
                87, 70, 110, 90, 86, 74, 108, 89, 87, 82,
                53, 99, 99, 108, 108, 80, 49, 0, 242, 4,
                51, 70, 112, 86, 70, 104, 48, 87, 69, 49,
                77, 79, 109, 78, 118, 98, 83, 53, 104, 48,
                0, 64, 53, 52, 98, 88, 33, 0, 240, 95,
                65, 65, 65, 68, 119, 47, 101, 72, 66, 104,
                89, 50, 116, 108, 100, 67, 66, 105, 90, 87,
                100, 112, 98, 106, 48, 105, 55, 55, 117, 47,
                73, 105, 66, 112, 90, 68, 48, 105, 86, 122,
                86, 78, 77, 69, 49, 119, 81, 50, 86, 111,
                97, 85, 104, 54, 99, 109, 86, 84, 101, 107,
                53, 85, 89, 51, 112, 114, 89, 122, 108, 107,
                73, 106, 56, 43, 73, 68, 120, 52, 79, 110,
                104, 116, 99, 71, 49, 108, 100, 71, 69, 103,
                101, 71, 49, 115, 98, 110, 77, 54, 101, 68,
                48, 105, 89, 87, 82, 118, 89, 109, 85, 54,
                16, 0, 243, 83, 98, 87, 86, 48, 89, 83,
                56, 105, 73, 72, 103, 54, 101, 71, 49, 119,
                100, 71, 115, 57, 73, 107, 70, 107, 98, 50,
                74, 108, 73, 70, 104, 78, 85, 67, 66, 68,
                98, 51, 74, 108, 73, 68, 85, 117, 78, 83,
                49, 106, 77, 68, 69, 48, 73, 68, 99, 53,
                76, 106, 69, 49, 77, 84, 81, 52, 77, 83,
                119, 103, 77, 106, 65, 120, 77, 121, 56, 119,
                77, 121, 56, 120, 77, 121, 48, 120, 77, 106,
                111, 119, 79, 84, 111, 120, 78, 83, 65, 103,
                73, 67, 4, 0, 229, 106, 52, 103, 80, 72,
                74, 107, 90, 106, 112, 83, 82, 69, 89, 144,
                0, 247, 49, 99, 109, 82, 109, 80, 83, 74,
                111, 100, 72, 82, 119, 79, 105, 56, 118, 100,
                51, 100, 51, 76, 110, 99, 122, 76, 109, 57,
                121, 90, 121, 56, 120, 79, 84, 107, 53, 76,
                122, 65, 121, 76, 122, 73, 121, 76, 88, 74,
                107, 90, 105, 49, 122, 101, 87, 53, 48, 89,
                88, 103, 116, 98, 110, 77, 106, 88, 0, 245,
                17, 69, 90, 88, 78, 106, 99, 109, 108, 119,
                100, 71, 108, 118, 98, 105, 66, 121, 90, 71,
                89, 54, 89, 87, 74, 118, 100, 88, 81, 57,
                73, 105, 73, 116, 0, 0, 232, 0, 245, 3,
                84, 85, 48, 57, 73, 109, 104, 48, 100, 72,
                65, 54, 76, 121, 57, 117, 99, 121, 140, 1,
                241, 3, 106, 98, 50, 48, 118, 101, 71, 70,
                119, 76, 122, 69, 117, 77, 67, 57, 116, 98,
                32, 1, 217, 104, 116, 98, 71, 53, 122, 79,
                110, 78, 48, 85, 109, 86, 180, 0, 67, 98,
                110, 77, 117, 84, 1, 240, 37, 117, 89, 50,
                57, 116, 76, 51, 104, 104, 99, 67, 56, 120,
                76, 106, 65, 118, 99, 49, 82, 53, 99, 71,
                85, 118, 85, 109, 86, 122, 98, 51, 86, 121,
                89, 50, 86, 83, 90, 87, 89, 106, 73, 105,
                66, 52, 98, 87, 120, 117, 99, 122, 112, 252,
                1, 15, 140, 0, 20, 0, 168, 1, 176, 104,
                116, 99, 69, 49, 78, 79, 107, 57, 121, 97,
                28, 2, 240, 4, 109, 70, 115, 82, 71, 57,
                106, 100, 87, 49, 108, 98, 110, 82, 74, 82,
                68, 48, 105, 224, 0, 247, 40, 76, 109, 82,
                112, 90, 68, 112, 109, 89, 87, 70, 104, 79,
                84, 100, 108, 89, 83, 48, 51, 89, 84, 90,
                107, 76, 84, 82, 104, 78, 68, 65, 116, 89,
                106, 85, 53, 78, 67, 48, 120, 78, 87, 81,
                52, 78, 71, 73, 122, 78, 122, 77, 52, 77,
                50, 69, 96, 0, 247, 54, 82, 118, 89, 51,
                86, 116, 90, 87, 53, 48, 83, 85, 81, 57,
                73, 110, 104, 116, 99, 67, 53, 107, 97, 87,
                81, 54, 79, 85, 89, 119, 81, 122, 66, 70,
                78, 106, 74, 71, 78, 48, 86, 66, 77, 84,
                70, 70, 77, 122, 108, 70, 78, 106, 86, 71,
                82, 84, 85, 120, 78, 69, 73, 53, 81, 48,
                89, 119, 79, 69, 77, 80, 0, 167, 108, 117,
                99, 51, 82, 104, 98, 109, 78, 108, 80, 0,
                26, 112, 80, 0, 31, 70, 80, 0, 19, 242,
                5, 68, 112, 68, 99, 109, 86, 104, 100, 71,
                57, 121, 86, 71, 57, 118, 98, 68, 48, 105,
                81, 212, 2, 241, 17, 103, 85, 71, 104, 118,
                100, 71, 57, 122, 97, 71, 57, 119, 73, 69,
                78, 68, 73, 67, 104, 88, 97, 87, 53, 107,
                98, 51, 100, 122, 75, 83, 73, 24, 3, 240,
                32, 98, 88, 66, 78, 84, 84, 112, 69, 90,
                88, 74, 112, 100, 109, 86, 107, 82, 110, 74,
                118, 98, 83, 66, 122, 100, 70, 74, 108, 90,
                106, 112, 112, 98, 110, 78, 48, 89, 87, 53,
                106, 90, 85, 108, 69, 80, 83, 74, 160, 1,
                240, 45, 117, 97, 87, 108, 107, 79, 109, 81,
                49, 78, 84, 82, 104, 77, 87, 81, 51, 76,
                84, 89, 53, 90, 84, 89, 116, 77, 122, 89,
                48, 90, 67, 49, 104, 77, 106, 66, 107, 76,
                84, 65, 121, 77, 68, 81, 119, 78, 122, 82,
                108, 90, 87, 77, 119, 90, 67, 73, 103, 99,
                51, 82, 240, 1, 47, 54, 90, 164, 1, 56,
                113, 76, 122, 52, 103, 80, 67, 57, 224, 2,
                240, 5, 82, 71, 86, 122, 89, 51, 74, 112,
                99, 72, 82, 112, 98, 50, 52, 43, 73, 68,
                119, 118, 84, 3, 80, 79, 108, 74, 69, 82,
                28, 3, 40, 67, 57, 8, 4, 0, 32, 0,
                8, 96, 4, 48, 108, 98, 109, 220, 1, 160,
                73, 105, 80, 122, 54, 100, 106, 82, 82, 119,
                132, 4, 240, 61, 77, 70, 66, 77, 86, 69,
                88, 110, 57, 102, 116, 87, 120, 102, 79, 54,
                53, 80, 85, 48, 117, 102, 65, 66, 111, 79,
                117, 67, 48, 47, 89, 105, 115, 79, 85, 87,
                115, 43, 57, 43, 117, 99, 119, 65, 114, 101,
                56, 65, 115, 118, 107, 84, 115, 101, 48, 65,
                114, 101, 48, 88, 115, 117, 55, 47, 47, 47,
                56, 65, 114, 79, 50, 118, 108, 82, 102, 50,
                80, 0, 240, 175, 104, 85, 108, 69, 81, 86,
                82, 52, 50, 108, 121, 80, 67, 119, 55, 69,
                73, 65, 104, 69, 69, 89, 101, 54, 105, 112,
                88, 55, 51, 55, 97, 103, 98, 116, 78, 50,
                111, 103, 107, 56, 74, 110, 120, 73, 116, 68,
                121, 107, 82, 99, 105, 43, 73, 118, 50, 65,
                48, 48, 107, 51, 102, 57, 48, 65, 82, 66,
                68, 69, 75, 117, 65, 103, 83, 86, 90, 100,
                72, 105, 84, 50, 101, 104, 112, 106, 85, 69,
                97, 81, 105, 106, 119, 52, 103, 90, 48, 119,
                116, 113, 101, 81, 108, 47, 48, 80, 43, 90,
                77, 122, 115, 108, 68, 97, 112, 77, 56, 101,
                48, 101, 97, 101, 68, 112, 78, 116, 54, 89,
                117, 89, 53, 107, 109, 105, 121, 121, 97, 72,
                69, 66, 72, 55, 53, 72, 55, 118, 68, 70,
                56, 78, 67, 121, 121, 80, 82, 47, 79, 65,
                102, 86, 101, 122, 43, 112, 81, 49, 79, 116,
                112, 98, 66, 47, 72, 118, 76, 98, 111, 69,
                71, 65, 65, 108, 68, 103, 121, 99, 110, 107,
                103, 54, 49, 81, 194, 0, 224, 66, 74, 82,
                85, 53, 69, 114, 107, 74, 103, 103, 103, 61, 61
            };
        }
    }
}
