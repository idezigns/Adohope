using Adohope.Modules.Notes.Models;
using System.Collections.Generic;

namespace Adohope.Modules.Notes.Repos
{
    public interface INoteRepository
    {
        void Add(Note note);
        List<Note> GetAll();
        void Remove(Note note);
    }
}