using Adohope.Modules.VoiceNotes.Models;
using System.Collections.Generic;

namespace Adohope.Modules.VoiceNotes.Repositories
{
    public interface IRecordingRepository
    {
        void Add(Recording asset);
        List<Recording> GetAll();
        void Remove(Recording asset);
    }
}