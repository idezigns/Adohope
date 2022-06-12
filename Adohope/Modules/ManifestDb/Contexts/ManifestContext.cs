using Adohope.Modules.ManifestDb.EntitiesConfigurations;
using Adohope.Modules.ManifestDb.Models;
using Microsoft.EntityFrameworkCore;

namespace Adohope.Modules.ManifestDb.Contexts
{
    public class ManifestContext : DbContext
    {
        public ManifestContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MBFile> MBFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MBFileConfiguration());
        }
    }
}
