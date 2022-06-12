using Adohope.Modules.Contacts.EntitiesConfigurations;
using Adohope.Modules.Contacts.Models;
using Microsoft.EntityFrameworkCore;

namespace Adohope.Modules.Contacts.Contexts
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        //public DbSet<MultiValue> MultiValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new MultiValueConfiguration());
        }
    }
}
