using Adohope.Modules.ManifestDb.Models;
using Adohope.Modules.Photos.Enums;

namespace Adohope.Modules.Photos.Models
{
    public class Asset
    {
        public long ID { get; set; }
        public AssetKind Kind { get; set; }
        public string Directory { get; set; }
        public string FileName { get; set; }
        public string RelativePath
        {
            get
            {
                if (!string.IsNullOrEmpty(Directory) && !string.IsNullOrEmpty(FileName))
                    return string.Join("/", new string[] { "Media", Directory, FileName });

                //return string.Empty;
                return null;
            }
        }
        public AssetKindSubType KindSubType { get; set; }
        //public AssetTag Tag { get; set; }
        public bool Favorite { get; set; }
        public bool Hidden { get; set; }
        public bool RecentlyDeleted { get; set; }
        public string ZUUID { get; set; }

        public IMBFile MBFile { get; set; }
    }
}
