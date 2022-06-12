using Adohope.Modules.ManifestDb.Enums;
using Adohope.Modules.ManifestDb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.ManifestDb.Repos
{
    public interface IMBFileRepository<TEntity> where TEntity : IMBFile
    {
        public List<TEntity> GetAll();
        public void Add(TEntity entity);
        public void Remove(TEntity entity);
        public List<TEntity> GetAllByDomain(string domainName);
        public TEntity GetByRelativePath(string relativePath);
        public List<TEntity> GetAllByFlag(FlagType mbFileFlag);
    }
}
