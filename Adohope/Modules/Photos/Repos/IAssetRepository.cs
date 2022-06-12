using Adohope.Modules.Photos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Photos.Repos
{
    public interface IAssetRepository
    {
        public List<Asset> GetAll();
        public void Add(Asset asset);
        public void Remove(Asset asset);
    }
}
