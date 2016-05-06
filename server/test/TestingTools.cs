using System;
using Google.Protobuf;
using System.Linq;

namespace KRPC.Test
{
    static class TestingTools
    {
        public static string ToHexString (this byte[] data)
        {
            return BitConverter.ToString (data).Replace ("-", "").ToLower ();
        }

        public static string ToHexString (this ByteString data)
        {
            return ToHexString (data.ToByteArray ());
        }

        public static byte[] ToBytes (this string data)
        {
            return Enumerable
                .Range (0, data.Length)
                .Where (x => x % 2 == 0)
                .Select (x => Convert.ToByte (data.Substring (x, 2), 16))
                .ToArray ();
        }

        public static ByteString ToByteString (this string data)
        {
            return ByteString.CopyFrom (data.ToBytes ());
        }
    }
}
