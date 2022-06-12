using Adohope.Modules.Notes.Models;
using Adohope.Modules.Notes.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Notes.Services
{
    public class NoteService
    {
        #region Constructors

        public NoteService(INoteRepository noteRepository)
        {
            NoteRepository = noteRepository;
        }

        #endregion

        #region Properties

        public INoteRepository NoteRepository { get; }

        #endregion

        #region Methods

        public List<Note> GetAllNotes()
        {
            var notes = NoteRepository.GetAll();

            return notes;
        }

        #endregion

    }
}
