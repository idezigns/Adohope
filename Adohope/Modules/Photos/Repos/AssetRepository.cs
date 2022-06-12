using Adohope.Modules.Photos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Adohope.Modules.Photos.Repos
{
    public class AssetRepository : IAssetRepository
    {
        #region Constructors

        public AssetRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        #endregion

        #region Fields

        public readonly DbContext DbContext;

        #endregion

        #region Interfaces

        public List<Asset> GetAll()
        {
            return DbContext.Set<Asset>().ToList();
        }

        public void Add(Asset asset)
        {
            DbContext.Set<Asset>().Add(asset);
        }

        public void Remove(Asset asset)
        {
            DbContext.Set<Asset>().Remove(asset);
        }

        #endregion
    }
}
