using Adohope.Modules.Messages.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Messages.EntitiesConfigurations
{
    public class ChatHandleJoinConfiguration : IEntityTypeConfiguration<ChatHandleJoin>
    {
        public void Configure(EntityTypeBuilder<ChatHandleJoin> builder)
        {
            builder.ToTable("chat_handle_join");

            builder.HasKey(t => new { t.Chat_ID, t.Handle_ID });

            builder.HasOne(c => c.Chat)
                .WithMany(c => c.ChatHandleJoin)
                .HasForeignKey(p => p.Chat_ID);

            builder.HasOne(c => c.Handle)
                .WithMany(c => c.ChatHandleJoins)
                .HasForeignKey(p => p.Handle_ID);
        }
    }
}
