using Adohope.Modules.Notes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adohope.Modules.Notes.Repos
{
    public class NoteRepository : INoteRepository
    {
        #region Constructors

        public NoteRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        #endregion

        #region Fields

        public readonly DbContext DbContext;

        #endregion

        #region Interfaces

        public List<Note> GetAll()
        {
            return DbContext.Set<Note>()
                .ToList();
        }

        public void Add(Note note)
        {
            DbContext.Set<Note>().Add(note);
        }

        public void Remove(Note note)
        {
            DbContext.Set<Note>().Remove(note);
        }

        #endregion

    }
}
