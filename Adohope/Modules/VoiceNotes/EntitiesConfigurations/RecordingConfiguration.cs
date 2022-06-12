using Adohope.Modules.VoiceNotes.Models;
using Adohope.Shared.Data.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adohope.Modules.VoiceNotes.EntitiesConfigurations
{
    public class RecordingConfiguration : IEntityTypeConfiguration<Recording>
    {
        public void Configure(EntityTypeBuilder<Recording> builder)
        {
            builder.ToTable("ZRECORDING");

            // ID
            builder.HasKey(p => p.ID);
            builder.Property(p => p.ID)
                .HasColumnName("Z_PK");

            // RecordingID
            builder.Property(p => p.RecordingID)
                .HasColumnName("ZRECORDINGID");

            // Date
            builder.Property(p => p.Date)
                .HasColumnName("ZDATE")
                .HasConversion<string>()
                .HasConversion(new CFTimeIntervalConverter());

            // Duration
            builder.Property(p => p.Duration)
                .HasColumnName("ZDURATION")
                .HasConversion(new DurationConverter());

            // Label
            builder.Property(p => p.Label)
                .HasColumnName("ZCUSTOMLABEL");

            // Path
            builder.Property(p => p.Path)
                .HasColumnName("ZPATH");

            // RelativePath
            builder.Ignore(p => p.RelativePath);

            // MBFile
            builder.Ignore(p => p.MBFile);
        }
    }
}
