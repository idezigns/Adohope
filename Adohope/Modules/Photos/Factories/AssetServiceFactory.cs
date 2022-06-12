using Adohope.Modules.ManifestDb.Services;
using Adohope.Modules.Photos.Contexts;
using Adohope.Modules.Photos.Repos;
using Adohope.Modules.Photos.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Photos.Factories
{
    public class AssetServiceFactory
    {
        public static AssetService CreateAssetService(string backupPath, Version productVersion, MBFileService mbfileService = null)
        {
            var contextFactory = new PhotosContextFactory(backupPath, productVersion);
            var photosContext = contextFactory.CreateDbContext();
            var assetRepository = new AssetRepository(photosContext);
            return new AssetService(assetRepository, mbfileService);
        }
    }
}
