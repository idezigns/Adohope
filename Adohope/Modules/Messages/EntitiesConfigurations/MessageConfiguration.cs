using Adohope.Modules.Messages.Models;
using Adohope.Shared.Data.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adohope.Modules.Messages.EntitiesConfigurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("message");

            // ID
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID)
                .HasColumnName("ROWID");

            // Text
            builder.Property(c => c.Text);

            // Handle
            //builder.Ignore(m => m.Handle);

            // Date_Read
            builder.Property(c => c.Date_Read)
                .HasConversion(new CFTimeIntervalConverter());

            // Date
            builder.Property(c => c.Date)
                .HasConversion(new CFTimeIntervalConverter());
        }
    }
}
