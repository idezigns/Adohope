using Adohope.Modules.Messages.Models;
using Adohope.Shared.Data.ValueConverters;
using Adohope.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Adohope.Modules.Messages.EntitiesConfigurations
{
    class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        #region Constructors

        public ChatConfiguration(string connectionString = null)
        {
            ConnectionString = connectionString;
        }

        #endregion

        #region Properties

        public string ConnectionString { get; }
        public static readonly string TableName = "chat";

        #endregion

        #region Interfaces

        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.ToTable(TableName);

            // ID
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID)
                .HasColumnName("ROWID");

            // Properties
            builder.Property(c => c.Properties)
                .HasConversion(new DynamicPListValueConverter());

            // ServiceType
            builder.Property(c => c.ServiceType)
                .HasColumnName("service_name")
                .HasConversion<long>();

            // AccountLogin
            builder.Property(c => c.AccountLogin)
                .HasColumnName("account_login")
                .HasConversion(new ValueConverter<AccountLogin, string>(
                    a => a.ToString() // will call tostring method in AccountLogin
                    , a => new AccountLogin(a)
                    ));

            // IsArchived
            builder.Property(c => c.IsArchived)
                .HasColumnName("is_archived");

            // LastReadMessageTimestamp

            // older versions like version 8.* has no last_read_message_timestamp field in Photos.sqlite database
            var fieldExists = true;
            if (ConnectionString != null)
            {
                fieldExists = SQLiteSchemaCheckerUtils.IsFieldExists(ConnectionString, TableName, "last_read_message_timestamp");
                if (!fieldExists)
                    builder.Ignore(p => p.LastReadMessageTimestamp);
            }

            if (fieldExists)
            {
                builder.Property(c => c.LastReadMessageTimestamp)
                    .HasColumnName("last_read_message_timestamp")
                    .HasConversion(new CFTimeIntervalConverter());
            }

            // Handle

            // Messages

            // ChatHandleJoin

        }

        #endregion

    }
}