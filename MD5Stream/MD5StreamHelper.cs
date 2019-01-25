using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Trinet.Core.IO.Ntfs;
using Utilities;

namespace MD5Stream
{
    public class MD5StreamHelper
    {
        public const string MD5StreamName = "MD5";

        public static MD5StreamStatus TestMD5Stream(FileInfo fileInfo)
        {
            byte[] fileHash = GetFileHash(fileInfo.FullName);
            AlternateDataStreamInfo md5StreamInfo = FileSystem.GetAlternateDataStream(fileInfo, MD5StreamName);

            if (md5StreamInfo.Exists)
            {
                Stream md5Stream = md5StreamInfo.OpenRead();
                MD5Descriptor descriptor = MD5Descriptor.ReadFromStream(md5Stream);
                if (descriptor == null)
                {
                    return MD5StreamStatus.Invalid;
                }

                if (DateTime.Equals(fileInfo.LastWriteTimeUtc, descriptor.FileWriteTimeUtc))
                {
                    if (ByteUtils.AreByteArraysEqual(fileHash, descriptor.FileHash))
                    {
                        return MD5StreamStatus.Correct;
                    }
                    else
                    {
                        return MD5StreamStatus.Incorrect;
                    }
                }
                else // file was updated since MD5 was stored
                {
                    SaveMD5Stream(md5StreamInfo, fileHash, fileInfo.LastWriteTimeUtc);
                    // We revert to the last write time before the ADS was written
                    File.SetLastWriteTimeUtc(fileInfo.FullName, fileInfo.LastWriteTimeUtc);
                    return MD5StreamStatus.Updated;
                }
            }
            else
            {
                SaveMD5Stream(md5StreamInfo, fileHash, fileInfo.LastWriteTimeUtc);
                // We revert to the last write time before the ADS was written
                File.SetLastWriteTimeUtc(fileInfo.FullName, fileInfo.LastWriteTimeUtc);
                return MD5StreamStatus.Created;
            }
        }

        public static void SaveMD5Stream(AlternateDataStreamInfo md5StreamInfo, byte[] fileHash, DateTime fileWriteTimeUtc)
        {
            FileStream md5Stream = md5StreamInfo.OpenWrite();
            MD5Descriptor descriptor = new MD5Descriptor();
            descriptor.FileHash = fileHash;
            descriptor.FileWriteTimeUtc = fileWriteTimeUtc;
            descriptor.WriteToStream(md5Stream);
            md5Stream.Close();
        }

        public static byte[] GetFileHash(string path)
        {
            MD5 md5 = MD5.Create();
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 16 * 1024 * 1024);
            byte[] fileHash = md5.ComputeHash(fileStream);
            fileStream.Close();
            return fileHash;
        }
    }
}
