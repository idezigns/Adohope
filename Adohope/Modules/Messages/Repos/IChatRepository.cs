using Adohope.Modules.Messages.Models;
using System.Collections.Generic;

namespace Adohope.Modules.Messages.Repos
{
    public interface IChatRepository
    {
        List<Chat> GetAll();
        void Add(Chat asset);
        void Remove(Chat asset);
    }
}