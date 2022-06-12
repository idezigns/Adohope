using Adohope.Shared.PList;
using Adohope.Modules.ManifestDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.ManifestDb.Models
{
    public class MBFile : IMBFile
    {
        public string FileID { get; set; }
        public string Domain { get; set; }
        public string RelativePath { get; set; }
        public FlagType Flags { get; set; }
        public DynamicPList File { get; set; }
    }
}
