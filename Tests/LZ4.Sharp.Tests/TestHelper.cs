
namespace LZ4.Sharp.Tests
{
    internal static class TestHelper
    {
        /// <summary>
        /// Create some data which can't be compressed because it is only
        /// one byte long.
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
        public static byte[] CreateValidTestData()
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
    }
}
