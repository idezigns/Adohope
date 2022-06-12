using Adohope.Modules.Contacts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adohope.Modules.Contacts.EntitiesConfigurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("ABPerson");

            builder.HasKey(p => p.RowID);

            builder.HasMany(p => p.MultiValues)
                .WithOne(m => m.Person)
                .HasForeignKey(m => m.Record_ID);
        }
    }
}
