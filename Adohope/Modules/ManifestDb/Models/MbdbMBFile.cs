using Adohope.Shared.PList;
using Adohope.Modules.ManifestDb.Enums;
using Adohope.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.ManifestDb.Models
{
    public class MbdbMBFile : IMBFile
    {
        protected string _fileID = string.Empty;

        public string FileID
        {
            get
            {
                if (_fileID == string.Empty)
                    _fileID = Sha1Utils.Hash(Domain + "-" + FileName);
                return _fileID;
            }
            set
            {
                _fileID = value;
            }
        }
        public string Domain { get; set; }
        public string RelativePath { get => FileName; set => FileName = value; }
        public FlagType Flags
        {
            get
            {
                return (Mode & 57344) switch
                {
                    16384 => FlagType.Direcotry,
                    32768 => FlagType.LocalFile,
                    40960 => FlagType.Symlink,
                    _ => throw new NotSupportedException("Unknown FileFlag")
                };
            }
            set
            {
                Mode = value switch
                {
                    FlagType.Direcotry => 16841,
                    FlagType.LocalFile => 33152,
                    FlagType.Symlink => 41453,
                    _ => throw new NotSupportedException("Unknown FileFlag")
                };
            }
        }
        public DynamicPList File { get; set; }


        public long StartOffset { get; set; }
        //public string Domain { get; set; }
        public string FileName { get; set; }
        public string LinkTarget { get; set; }
        public string DataHash { get; set; }
        public string Unknown1 { get; set; }
        public int Mode { get; set; }
        public int Unknown2 { get; set; }
        public int Unknown3 { get; set; }
        public int UserID { get; set; }
        public int GroupID { get; set; }
        public int MTime { get; set; }
        public int ATime { get; set; }
        public int CTime { get; set; }
        public int FileLen { get; set; }
        public int Flag { get; set; }
        public int NumProps { get; set; }
        public Dictionary<string, string> Properties { get; set; }
    }
}
