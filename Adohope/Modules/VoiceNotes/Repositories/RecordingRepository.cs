using Adohope.Modules.VoiceNotes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Adohope.Modules.VoiceNotes.Repositories
{
    public class RecordingRepository : IRecordingRepository
    {
        #region Constructors

        public RecordingRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        #endregion

        #region Fields

        public readonly DbContext DbContext;

        #endregion

        #region Interfaces

        public List<Recording> GetAll()
        {
            return DbContext.Set<Recording>().ToList();
        }

        public void Add(Recording asset)
        {
            DbContext.Set<Recording>().Add(asset);
        }

        public void Remove(Recording asset)
        {
            DbContext.Set<Recording>().Remove(asset);
        }

        #endregion

    }
}
