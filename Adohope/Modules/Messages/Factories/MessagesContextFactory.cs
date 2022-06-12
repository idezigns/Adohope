
using Adohope.Modules.Messages.Contexts;
using Adohope.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Messages.Factories
{
    public class MessagesContextFactory : IDesignTimeDbContextFactory<MessagesContext>
    {
        public MessagesContextFactory(string backupPath)
        {
            BackupPath = backupPath;
        }

        public string BackupPath { get; }

        public MessagesContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MessagesContext>();

            optionsBuilder
                .UseSqlite("Data Source=" + PathUtils.MBFilePath(BackupPath, "3d0d7e5fb2ce288813306e4d4636395e047a3d28"));

            return new MessagesContext(optionsBuilder.Options);
        }
    }
}
