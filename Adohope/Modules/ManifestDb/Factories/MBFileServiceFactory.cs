using Adohope.Modules.ManifestDb.Contexts;
using Adohope.Modules.ManifestDb.Models;
using Adohope.Modules.ManifestDb.Repos;
using Adohope.Modules.ManifestDb.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.ManifestDb.Factories
{
    public class MBFileServiceFactory
    {
        public static MBFileService CreateMBFileService(Backup backup)
        {
            //todo: handle exception if cannot create repository!
            IMBFileRepository<IMBFile> mbfileRepository = MBFileRepositoryFactory.CreateMBFileRepository(backup);

            MBFileService mbfileService = new MBFileService(mbfileRepository);

            return mbfileService;
        }
    }
}
