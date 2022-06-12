using Adohope.Modules.Notes.Models;
using Adohope.Modules.Notes.ValuesConverters;
using Adohope.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Notes.EntitiesConfigurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        #region Constructors

        public NoteConfiguration()
        {
            TableName = "ZICNOTEDATA";
        }

        #endregion

        #region Fields

        public static string TableName;

        #endregion

        #region Methods

        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(n => n.Z_PK);

            builder.Property(p => p.ZDATA)
                .HasConversion(new BinaryNoteConverter());
        }

        #endregion

    }
}
