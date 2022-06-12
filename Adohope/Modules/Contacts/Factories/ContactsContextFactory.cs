using Adohope.Modules.Contacts.Contexts;
using Adohope.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Contacts.Factories
{
    public class ContactsContextFactory : IDesignTimeDbContextFactory<ContactsContext>
    {
        public ContactsContextFactory(string backupPath)
        {
            BackupPath = backupPath;
        }

        public string BackupPath { get; }

        public ContactsContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContactsContext>();

            optionsBuilder
                .UseSqlite("Data Source=" + PathUtils.MBFilePath(BackupPath, "31bb7ba8914766d4ba40d6dfb6113c8b614be442"));

            return new ContactsContext(optionsBuilder.Options);
        }
    }
}
