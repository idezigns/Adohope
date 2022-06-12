using Adohope.Modules.ManifestDb.Contexts;
using Adohope.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.ManifestDb.Factories
{
    public class ManifestContextFactory : IDesignTimeDbContextFactory<ManifestContext>
    {
        public ManifestContextFactory(string backupPath)
        {
            BackupPath = backupPath;
        }

        public string BackupPath { get; }

        public ManifestContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ManifestContext>();

            optionsBuilder
                .UseSqlite("Data Source=" + PathUtils.ManifestFilePath(BackupPath, "Manifest.db"));

            return new ManifestContext(optionsBuilder.Options);
        }
    }
}
