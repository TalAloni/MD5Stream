using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Utilities;

namespace MD5Stream
{
    public class MD5Descriptor
    {
        public byte[] FileHash;
        public DateTime FileWriteTimeUtc;

        public MD5Descriptor()
        {
        }

        public void WriteToStream(Stream stream)
        {
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine("MD5={0}", ToHexString(FileHash));
            writer.WriteLine("FileWriteTimeUtc={0}", FileWriteTimeUtc.ToString("o"));
            writer.Flush();
        }

        /// <summary>
        /// Will return null if descriptor is invalid
        /// </summary>
        public static MD5Descriptor ReadFromStream(Stream stream)
        {
            Dictionary<string, string> properties;
            try
            {
                properties = ReadProperties(stream);
            }
            catch(ArgumentException)
            {
                return null;
            }

            if (properties == null)
            {
                return null;
            }

            if (properties.ContainsKey("MD5") && properties.ContainsKey("FileWriteTimeUtc"))
            {
                MD5Descriptor descriptor = new MD5Descriptor();
                string md5String = properties["MD5"];
                string fileWriteTimeUtcString = properties["FileWriteTimeUtc"];
                try
                {
                    descriptor.FileHash = HexStringToBytes(md5String);
                    descriptor.FileWriteTimeUtc = DateTime.Parse(fileWriteTimeUtcString, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                }
                catch
                {
                    return null;
                }
                return descriptor;
            }
            return null;
        }

        /// <summary>
        /// Will return null or throw exception if format is invalid
        /// </summary>
        public static Dictionary<string, string> ReadProperties(Stream stream)
        {
            Dictionary<string, string> result = new Dictionary<string,string>();
            StreamReader reader = new StreamReader(stream);
            string line = reader.ReadLine();
            while (line != null)
            {
                int index = line.IndexOf('=');
                if (index > 0)
                {
                    string key = line.Substring(0, index);
                    string value = line.Substring(index + 1);
                    if (result.ContainsKey(key))
                    {
                        return null;
                    }
                    result.Add(key, value);
                }
                else
                {
                    return null;
                }
                line = reader.ReadLine();
            }
            reader.Close();
            return result;
        }

        public static string ToHexString(byte[] bytes)
        {
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("X2"));
            }

            return builder.ToString();
        }

        public static byte[] HexStringToBytes(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException("Hex string cannot have an odd number of digits");
            }

            byte[] result = new byte[hexString.Length / 2];
            for (int index = 0; index < result.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                result[index] = byte.Parse(byteValue, NumberStyles.HexNumber);
            }

            return result;
        }
    }
}
