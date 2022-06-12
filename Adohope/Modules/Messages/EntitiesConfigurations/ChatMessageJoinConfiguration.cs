using Adohope.Modules.Messages.Models;
using Adohope.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Messages.EntitiesConfigurations
{
    public class ChatMessageJoinConfiguration : IEntityTypeConfiguration<ChatMessageJoin>
    {
        #region Constructors

        public ChatMessageJoinConfiguration(string connectionString = null)
        {
            ConnectionString = connectionString;
        }

        #endregion

        #region Properties

        public string ConnectionString { get; }

        #endregion

        #region Fields

        public static readonly string TableName = "chat_message_join";

        #endregion

        #region Interfaces

        public void Configure(EntityTypeBuilder<ChatMessageJoin> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(t => new { t.Chat_ID, t.Message_Id });

            builder.HasOne(t => t.Chat)
                .WithMany(t => t.ChatMessageJoins)
                .HasForeignKey(t => t.Chat_ID);

            builder.HasOne(t => t.Message)
                .WithMany(t => t.ChatMessageJoins)
                .HasForeignKey(t => t.Message_Id);

            // older versions like version 8.* has no message_date field in Photos.sqlite database
            if (ConnectionString != null)
            {
                var messageDateFieldExists = SQLiteSchemaCheckerUtils.IsFieldExists(ConnectionString, TableName, "message_date");
                if (!messageDateFieldExists)
                    builder.Ignore(p => p.Message_Date);
            }
        }

        #endregion
    }
}
