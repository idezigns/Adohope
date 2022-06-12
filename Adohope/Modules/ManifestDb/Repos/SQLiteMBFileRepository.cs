using Adohope.Modules.ManifestDb.Contexts;
using Adohope.Modules.ManifestDb.Enums;
using Adohope.Modules.ManifestDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Adohope.Modules.ManifestDb.Repos
{
    public class SQLiteMBFileRepository : IMBFileRepository<IMBFile>
    {
        #region Constructors

        public SQLiteMBFileRepository(ManifestContext dbContext)
        {
            DbContext = dbContext;
        }

        #endregion

        #region Properties

        public ManifestContext DbContext { get; }

        #endregion

        #region Interfaces

        public List<IMBFile> GetAllByDomain(string domainName)
        {
            var mbFiles = DbContext.Set<MBFile>().Where(e => e.Domain == domainName).ToList();

            return CastList(mbFiles);
        }

        public IMBFile GetByRelativePath(string relativePath)
        {
            IMBFile mbFile = DbContext.Set<MBFile>().Where(e => e.RelativePath == relativePath).FirstOrDefault();

            return mbFile;
        }

        public List<IMBFile> GetAllByFlag(FlagType mbFileFlag)
        {
            try
            {
                var mbFiles = DbContext.Set<MBFile>()
                    .Where(e => e.Flags == mbFileFlag)
                    .ToList();

                return CastList(mbFiles);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<IMBFile> GetAll()
        {
            try
            {
                var mbFiles = DbContext.Set<MBFile>().ToList();
                return CastList(mbFiles);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Add(IMBFile entity)
        {
            try
            {
                _ = entity ?? throw new ArgumentNullException();

                DbContext.Set<MBFile>().Add((MBFile)entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(IMBFile entity)
        {
            try
            {
                _ = entity ?? throw new ArgumentNullException();

                DbContext.Set<MBFile>().Remove((MBFile)entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Method

        protected List<IMBFile> CastList(List<MBFile> list)
        {
            return list.Cast<IMBFile>().ToList();
        }

        #endregion
    }
}
