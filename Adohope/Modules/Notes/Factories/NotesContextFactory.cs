using Adohope.Modules.Notes.Contexts;
using Adohope.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Notes.Factories
{
    public class NotesContextFactory : IDesignTimeDbContextFactory<NotesContext>
    {
        public NotesContextFactory(string backupPath)
        {
            BackupPath = backupPath;
        }

        public string BackupPath { get; }

        public NotesContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NotesContext>();

            optionsBuilder
                .UseSqlite("Data Source=" + PathUtils.MBFilePath(BackupPath, "4f98687d8ab0d6d1a371110e6b7300f6e465bef2"));

            return new NotesContext(optionsBuilder.Options);
        }
    }
}
