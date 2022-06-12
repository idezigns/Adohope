using Adohope.Modules.VoiceNotes.Contexts;
using Adohope.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.VoiceNotes.Factories
{
    public class VoiceNotesContextFactory : IDesignTimeDbContextFactory<VoiceNotesContext>
    {

        public VoiceNotesContextFactory(string backupPath)
        {
            BackupPath = backupPath;
        }

        public string BackupPath { get; }

        public VoiceNotesContext CreateDbContext(string[] args =null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VoiceNotesContext>();

            optionsBuilder
                .UseSqlite("Data Source=" + PathUtils.MBFilePath(BackupPath, "303e04f2a5b473c5ca2127d65365db4c3e055c05"));

            return new VoiceNotesContext(optionsBuilder.Options);
        }
    }
}
