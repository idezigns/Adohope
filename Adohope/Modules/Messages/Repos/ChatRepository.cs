using Adohope.Modules.Messages.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adohope.Modules.Messages.Repos
{
    public class ChatRepository : IChatRepository
    {
        #region Constructors

        public ChatRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        #endregion

        #region Fields

        public readonly DbContext DbContext;

        #endregion

        #region Interfaces

        public List<Chat> GetAll()
        {
            return DbContext.Set<Chat>()
                //.Include(c => c.ChatMessageJoins)
                .Include(nameof(Chat.ChatMessageJoins) + "." + nameof(ChatMessageJoin.Message))
                .Include(nameof(Chat.ChatHandleJoin) + "." + nameof(ChatHandleJoin.Handle))
                .ToList();
        }

        public void Add(Chat asset)
        {
            DbContext.Set<Chat>().Add(asset);
        }

        public void Remove(Chat asset)
        {
            DbContext.Set<Chat>().Remove(asset);
        }

        #endregion
    }
}
