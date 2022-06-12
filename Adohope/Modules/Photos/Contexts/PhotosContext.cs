using Adohope.Modules.Photos.EntitiesConfigurations;
using Adohope.Modules.Photos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite.Infrastructure.Internal;

namespace Adohope.Modules.Photos.Contexts
{
    public class PhotosContext : DbContext
    {
        #region Constructors

        public PhotosContext(DbContextOptions options/*, Version productVersion*/) : base(options)
        {
            //ProductVersion = productVersion;
            ConnectionString = options.FindExtension<SqliteOptionsExtension>().ConnectionString;
        }

        #endregion

        #region Properties

        public DbSet<Asset> Assets { get; set; }

        public string ConnectionString { get; }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AssetConfiguration(ConnectionString));
        }

        #endregion
    }
}
