using Adohope.Modules.ManifestDb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Adohope.Shared.Utils
{
    public class MbdbUtils
    {
        public static Dictionary<long, MbdbMBFile> ProcessMBDBFile(string mbdbFilePath)
        {
            BinaryReader br = new BinaryReader(File.OpenRead(mbdbFilePath));

            //        <Start Offest, MbdbMBFile>
            Dictionary<long, MbdbMBFile> filesInfo = new Dictionary<long, MbdbMBFile>();

            MbdbMBFile mbdbMBFile;

            // Check if file is valid mbdb
            if (Encoding.UTF8.GetString(br.ReadBytes(4)) != "mbdb")
                throw new InvalidDataException("This does not look like an MBDB file");

            /*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                * Start reading files info
                *++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/

            br.BaseStream.Position = 6;

            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                mbdbMBFile = new MbdbMBFile();

                mbdbMBFile.StartOffset = br.BaseStream.Position;

                mbdbMBFile.Domain = ReadString(br);
                mbdbMBFile.FileName = ReadString(br);
                mbdbMBFile.LinkTarget = ReadString(br);
                mbdbMBFile.DataHash = ReadString(br);
                mbdbMBFile.Unknown1 = ReadString(br);
                mbdbMBFile.Mode = ReadInt(br, 2);
                mbdbMBFile.Unknown2 = ReadInt(br, 4);
                mbdbMBFile.Unknown3 = ReadInt(br, 4);
                mbdbMBFile.UserID = ReadInt(br, 4);
                mbdbMBFile.GroupID = ReadInt(br, 4);
                mbdbMBFile.MTime = ReadInt(br, 4);
                mbdbMBFile.ATime = ReadInt(br, 4);
                mbdbMBFile.CTime = ReadInt(br, 4);
                mbdbMBFile.FileLen = ReadInt(br, 8);
                mbdbMBFile.Flag = ReadInt(br, 1);
                mbdbMBFile.NumProps = ReadInt(br, 1);
                mbdbMBFile.Properties = new Dictionary<string, string>();

                for (int i = 0; i < mbdbMBFile.NumProps; i++)
                    mbdbMBFile.Properties.Add(ReadString(br), ReadString(br));

                filesInfo.Add(mbdbMBFile.StartOffset, mbdbMBFile);
            }


            return filesInfo;
        }

        public static Dictionary<long, string> ProcessMBDXFile(string mbdxFilePath)
        {
            BinaryReader br = new BinaryReader(File.OpenRead(mbdxFilePath));

            //        <Start Offest, fileID_string>
            Dictionary<long, string> filesIDs = new Dictionary<long, string>();

            // Check if file is valid mbdb
            if (Encoding.UTF8.GetString(br.ReadBytes(4)) != "mbdx")
                throw new InvalidDataException("This does not look like an MBDX file");

            /*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                * Start reading files info
                *++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/

            // offset 4 and 5, not sure what this is
            // offset 6 + 4, count of records
            br.BaseStream.Position = 10;

            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                // 26 byte record, make up of ..

                string fileID = Encoding.UTF8.GetString(br.ReadBytes(20));

                int mbdbOffset = ReadInt(br, 4); // 4-byte offset field
                mbdbOffset += 6; // Add 6 to get past prolog

                //int mode = ReadInt(br, 2); // 2-byte mode field
                br.BaseStream.Position += 2;

                filesIDs.Add(mbdbOffset, fileID);
            }

            return filesIDs;
        }

        public static int ReadInt(BinaryReader reader, int intSize)
        {
            var value = 0;

            while (intSize > 0)
            {
                value = (value << 8) + reader.ReadByte();
                intSize -= 1;
            }

            return value;
        }

        public static string ReadString(BinaryReader reader)
            {
                // Check if string is blank
                byte firstByte = reader.ReadByte();
                byte secondByte = reader.ReadByte();

                if (firstByte == 255 && secondByte == 255)
                    return "";

                // Reset offset position
                reader.BaseStream.Position -= 2;

                // Read string
                int stringLength = ReadInt(reader, 2);

                byte[] stringBytes = reader.ReadBytes(stringLength);

                string encodedString = Encoding.UTF8.GetString(stringBytes);

                return encodedString;
            }
    }
}
