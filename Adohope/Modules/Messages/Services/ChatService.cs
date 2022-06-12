using Adohope.Modules.ManifestDb.Services;
using Adohope.Modules.Messages.Models;
using Adohope.Modules.Messages.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Messages.Services
{
    public class ChatService
    {
        #region Constructors

        public ChatService(IChatRepository assetRepository)
        {
            ChatRepository = assetRepository;
        }

        #endregion

        #region Properties

        public IChatRepository ChatRepository { get; }

        #endregion

        #region Methods

        public List<Chat> GetAllChats()
        {
            var chats = ChatRepository.GetAll();

            return chats;
        }

        #endregion
    }
}
