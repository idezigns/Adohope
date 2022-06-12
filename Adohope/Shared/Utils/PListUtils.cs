using PListNet;
using PListNet.Nodes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Adohope.Shared.Utils
{
    public class PListUtils
    {
        public static DictionaryNode Load(Stream stream)
        {
            return PListNet.PList.Load(stream) as DictionaryNode;
        }
        public static DictionaryNode Load(byte[] buffer)
        {
            return Load(new MemoryStream(buffer));
        }
        public static DictionaryNode Load(string filePath)
        {
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                DictionaryNode rootNode = Load(fs);
                fs.Close();

                return rootNode;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Save(Stream stream, PNode rootNode, PListFormat format)
        {
            PListNet.PList.Save(rootNode, stream, format);
        }
        public static void Save(string filePath, PNode rootNode, PListFormat format = PListFormat.Binary)
        {
            FileStream fs = File.OpenWrite(filePath);
            Save(fs, rootNode, format);
            fs.Close();
        }
    }
}
