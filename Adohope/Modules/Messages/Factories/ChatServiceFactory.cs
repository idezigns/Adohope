using Adohope.Modules.ManifestDb.Services;
using Adohope.Modules.Messages.Contexts;
using Adohope.Modules.Messages.Repos;
using Adohope.Modules.Messages.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Messages.Factories
{
    public class ChatServiceFactory
    {
        public static ChatService CreateService(string backupPath)
        {
            var contextFactory = new MessagesContextFactory(backupPath);
            var messagesContext = contextFactory.CreateDbContext();
            var chatRepository = new ChatRepository(messagesContext);
            return new ChatService(chatRepository);
        }
    }
}
