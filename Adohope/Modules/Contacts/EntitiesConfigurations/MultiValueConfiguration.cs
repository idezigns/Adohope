using Adohope.Modules.Contacts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adohope.Modules.Contacts.EntitiesConfigurations
{
    public class MultiValueConfiguration : IEntityTypeConfiguration<MultiValue>
    {
        public void Configure(EntityTypeBuilder<MultiValue> builder)
        {
            builder.ToTable("ABMultiValue");

            builder.HasKey(mv => mv.UID);

            builder.HasOne(mv => mv.Person)
                .WithMany(p => p.MultiValues)
                .HasForeignKey(mv => mv.Record_ID);
        }
    }
}
