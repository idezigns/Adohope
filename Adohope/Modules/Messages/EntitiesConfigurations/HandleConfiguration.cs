using Adohope.Modules.Messages.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adohope.Modules.Messages.EntitiesConfigurations
{
    class HandleConfiguration : IEntityTypeConfiguration<Handle>
    {
        public void Configure(EntityTypeBuilder<Handle> builder)
        {
            builder.ToTable("handle");

            // ID
            builder.HasKey(h => h.ID);
            builder.Property(h => h.ID)
                .HasColumnName("ROWID");

            // HandlerID
            builder.Property(h => h.HandlerID)
                .HasColumnName("id");

            // UncanonicalizedID
            builder.Property(h => h.UncanonicalizedID)
                .HasColumnName("uncanonicalized_id");
        }
    }
}
