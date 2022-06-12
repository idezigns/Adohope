using Adohope.Modules.Notes.Contexts;
using Adohope.Modules.Notes.Repos;
using Adohope.Modules.Notes.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Notes.Factories
{
    public class NoteServiceFactory
    {
        public static NoteService CreateService(string backupPath)
        {
            var contextFactory = new NotesContextFactory(backupPath);
            var notesContext = contextFactory.CreateDbContext();
            var noteRepository = new NoteRepository(notesContext);
            return new NoteService(noteRepository);
        }
    }
}
