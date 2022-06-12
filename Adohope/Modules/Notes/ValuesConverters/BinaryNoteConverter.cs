using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq.Expressions;
using System.Text;

namespace Adohope.Modules.Notes.ValuesConverters
{
    public class BinaryNoteConverter : ValueConverter<string, byte[]>
    {
        public BinaryNoteConverter(ConverterMappingHints mappingHints = null)
            : base(convertToProviderExpression, convertFromProviderExpression, mappingHints)
        {
        }

        private static Expression<Func<string, byte[]>> convertToProviderExpression = x => ConvertTo(x);

        private static Expression<Func<byte[], string>> convertFromProviderExpression = x => ConvertFrom(x);

        public static byte[] ConvertTo(string x)
        {
            throw new NotImplementedException();
        }

        public static string ConvertFrom(byte[] x)
        {
            // load bytes to memrystream
            // extract note from the .gz file
            // load the extracted note file to memory stream
            // read bytes and get string length
            // load string and return it

            // ==============================================
            //https://reverseengineering.stackexchange.com/questions/14387/reversing-ios-notes-file-format

            //MemoryStream noteStream = DecompressGZip(x) as MemoryStream;


            MemoryStream noteStream;

            try
            {
                noteStream = DecompressGZip(x) as MemoryStream;
            }
            catch (Exception)
            {
                StringBuilder sb = new StringBuilder();
                foreach (byte b in x)
                {
                    sb.Append(b.ToString("x2"));
                }
                string bytesInString = sb.ToString();
                return string.Empty;
            }


            if (noteStream == null) return "";

            noteStream.Seek(11 /* first byte after 0A|11 */, SeekOrigin.Begin);
            int intByte = noteStream.ReadByte();
            string nibblesForm = Convert.ToString(intByte, 2).PadLeft(8, '0');
            bool isBitSet = (intByte & (1 << 8 - 1)) != 0;

            int noteLength = 0;

            if (isBitSet)
            {
                noteStream.Seek(2, SeekOrigin.Current);
            }
            else
            {
                noteStream.Seek(1, SeekOrigin.Current);
            }


            intByte = noteStream.ReadByte();
            isBitSet = (intByte & (1 << 8 - 1)) != 0;

            if (isBitSet)
            {
                nibblesForm = Convert.ToString(intByte, 2).PadLeft(8, '0');
                int shiftedInt2 = intByte & ~(1 << 7); // remove leftmost bit
                string shiftedIntString2 = Convert.ToString(shiftedInt2, 2); //.PadLeft(8, '0')

                int secondByte = noteStream.ReadByte();
                string shiftedIntString4 = Convert.ToString(secondByte, 2); //.PadLeft(8, '0')

                int value = (secondByte << 7) | shiftedInt2;
                string shiftedIntString3 = Convert.ToString(value, 2); //.PadLeft(8, '0')

                noteLength = value;
            }
            else
            {
                noteLength = intByte;
            }


            //byte[] noteText = new byte[noteStream.Length];
            int pos = (int)noteStream.Position;
            byte[] noteText = new byte[(noteStream.Length > noteLength ? noteStream.Length : noteLength) + pos];
            //noteStream.Position = 0;
            noteStream.Read(noteText, pos, noteLength);

            string noteTextString = Encoding.UTF8.GetString(noteText);




            return noteTextString;
        }

        private static Stream DecompressGZip(byte[] noteContent)
        {
            MemoryStream inStream = new MemoryStream(noteContent);

            // is zipped file?
            byte[] fileSignture = new byte[2];
            inStream.Read(fileSignture, 0, 2);
            inStream.Seek(0, SeekOrigin.Begin);

            // .gz
            if (fileSignture[0] == 0x1F && fileSignture[1] == 0x8B)
            {
                MemoryStream outStream = new MemoryStream();

                using (GZipStream gzip = new GZipStream(inStream, CompressionMode.Decompress))
                {
                    gzip.CopyTo(outStream);
                }

                outStream.Seek(0, SeekOrigin.Begin);
                return outStream;
            }

            // .zlib
            if (fileSignture[0] == 0x78 && fileSignture[1] == 0x9c)
            {
                MemoryStream outStream = new MemoryStream();

                using (ZipArchive zlib = new ZipArchive(inStream, ZipArchiveMode.Read))
                {
                    zlib.Entries[0].Open().CopyTo(outStream);
                }

                outStream.Seek(0, SeekOrigin.Begin);
                return outStream;
            }



            return inStream;
        }
    }
}
