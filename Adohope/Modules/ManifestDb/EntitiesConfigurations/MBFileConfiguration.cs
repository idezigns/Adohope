using Adohope.Modules.ManifestDb.Models;
using Adohope.Shared.Data.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adohope.Modules.ManifestDb.EntitiesConfigurations
{
    public class MBFileConfiguration : IEntityTypeConfiguration<MBFile>
    {
        public void Configure(EntityTypeBuilder<MBFile> builder)
        {
            builder.ToTable("Files");

            // FileID
            builder.HasKey(p => p.FileID);

            // Flags
            builder.Property(p => p.Flags)
                .HasConversion<long>();

            // File
            builder.Property(p => p.File)
                .HasConversion(new PListValueConverter());
        }
    }
}
