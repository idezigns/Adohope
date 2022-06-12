using Adohope.Modules.Photos.Contexts;
using Adohope.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Photos.Factories
{
    public class PhotosContextFactory : IDesignTimeDbContextFactory<PhotosContext>
    {
        public PhotosContextFactory(string backupPath, Version productVersion)
        {
            BackupPath = backupPath;
            ProductVersion = productVersion;
        }

        public string BackupPath { get; }
        public Version ProductVersion { get; }

        public PhotosContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PhotosContext>();

            var filePath = PathUtils.MBFilePath(BackupPath, "12b144c0bd44f2b3dffd9186d3f9c05b917cee25");

            optionsBuilder
                .UseSqlite("Data Source=" + filePath);

            return new PhotosContext(optionsBuilder.Options/*, ProductVersion*/);
        }
    }
}
