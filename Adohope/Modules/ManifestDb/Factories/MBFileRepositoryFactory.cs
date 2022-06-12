using Adohope.Modules.ManifestDb.Contexts;
using Adohope.Modules.ManifestDb.Models;
using Adohope.Modules.ManifestDb.Repos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Adohope.Modules.ManifestDb.Factories
{
    public class MBFileRepositoryFactory
    {
        public static IMBFileRepository<IMBFile> CreateMBFileRepository(Backup backup)
        {
            return GuessDatabaseTypeBySystemVersion(backup) ??
                GuessDatabaseTypeByManullyFindingFiles(backup) ??
                throw new Exception("Cannot determine whether the manifest database is SQLite file or MBDB");
        }

        protected static IMBFileRepository<IMBFile> GuessDatabaseTypeBySystemVersion(Backup backup)
        {
            // ==================================================================
            // Status.plist file has key named (version) where it holds the version
            // numbder value.
            //
            // For version 3.2 and later the manifest database is a SQLite file
            // named (Manifest.db), for the versions less then that version, 
            // the manfiest database file is an MBDB file.
            // ==================================================================

            try
            {
                var version = double.Parse(backup.Status().Version);

                if (version >= 3.2)
                    return new SQLiteMBFileRepository((new ManifestContextFactory(backup.BackupPath)).CreateDbContext());
                else
                    return new MbdbMBFileRepository(backup.BackupPath);
            }
            catch (Exception) { return null; }
        }

        protected static IMBFileRepository<IMBFile> GuessDatabaseTypeByManullyFindingFiles(Backup backup)
        {
            try
            {
                if (File.Exists(Path.Combine(backup.BackupPath, "Manifest.db")))
                    return new SQLiteMBFileRepository((new ManifestContextFactory(backup.BackupPath)).CreateDbContext());

                if (File.Exists(Path.Combine(backup.BackupPath, "Manifest.mbdb")))
                    return new MbdbMBFileRepository(backup.BackupPath);

                return null;
            }
            catch (Exception) { return null; }
        }
    }
}
