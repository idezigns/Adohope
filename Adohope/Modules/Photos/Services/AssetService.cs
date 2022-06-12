using Adohope.Modules.ManifestDb.Contexts;
using Adohope.Modules.ManifestDb.Models;
using Adohope.Modules.ManifestDb.Services;
using Adohope.Modules.Photos.Models;
using Adohope.Modules.Photos.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Photos.Services
{
    public class AssetService
    {
        #region Constructors

        public AssetService(IAssetRepository assetRepository, MBFileService mbfileService = null)
        {
            AssetRepository = assetRepository;
            MBFileService = mbfileService;
        }

        #endregion

        #region Properties

        public IAssetRepository AssetRepository { get; }
        public MBFileService MBFileService { get; }

        #endregion

        #region Methods

        public List<Asset> GetAllAssets()
        {
            var assets = AssetRepository.GetAll();

            if (MBFileService == null) return assets;

            foreach (Asset asset in assets)
                asset.MBFile = (IMBFile)MBFileService.GetByRelativePath(asset.RelativePath);

            return assets;
        }

        #endregion
    }
}
