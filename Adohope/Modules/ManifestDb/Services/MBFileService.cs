using Adohope.Modules.ManifestDb.Enums;
using Adohope.Modules.ManifestDb.Models;
using Adohope.Modules.ManifestDb.Repos;
using System.Collections.Generic;

namespace Adohope.Modules.ManifestDb.Services
{
    public class MBFileService
    {
        #region Constructors

        public MBFileService(IMBFileRepository<IMBFile> mbFileRepository)
        {
            MbFileRepository = mbFileRepository;
        }

        #endregion

        #region Properties

        public IMBFileRepository<IMBFile> MbFileRepository { get; }

        #endregion

        #region Methods

        public List<IMBFile> GetAllBackupFiles()
        {
            return MbFileRepository.GetAll();
        }

        public List<IMBFile> GetAllPhysicalFiles()
        {
            return MbFileRepository.GetAllByFlag(FlagType.LocalFile);
        }

        public List<IMBFile> GetAllLogicalFiles()
        {
            return MbFileRepository.GetAllByFlag(FlagType.Buffer);
        }

        public List<IMBFile> GetAllByDomain(string domainName)
        {
            return MbFileRepository.GetAllByDomain(domainName);
        }

        public IMBFile GetByRelativePath(string relativePath)
        {
            return MbFileRepository.GetByRelativePath(relativePath);
        }

        #endregion
    }
}
