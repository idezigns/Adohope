using Adohope.Modules.Messages.EntitiesConfigurations;
using Adohope.Modules.Messages.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite.Infrastructure.Internal;

namespace Adohope.Modules.Messages.Contexts
{
    public class MessagesContext : DbContext
    {
        #region Constructors

        public MessagesContext(DbContextOptions options) : base(options)
        {
            //todo: Note that this SqliteOptionsExtension is an internal class which means that the class may changed or removed
            // at anytime
            ConnectionString = options.FindExtension<SqliteOptionsExtension>()?.ConnectionString;
        }

        #endregion

        #region Properties

        public string ConnectionString { get; }
        public DbSet<Chat> Chats { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HandleConfiguration());
            modelBuilder.ApplyConfiguration(new ChatConfiguration(ConnectionString));
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new ChatMessageJoinConfiguration(ConnectionString));
            modelBuilder.ApplyConfiguration(new ChatHandleJoinConfiguration());
        }

        #endregion
    }
}
