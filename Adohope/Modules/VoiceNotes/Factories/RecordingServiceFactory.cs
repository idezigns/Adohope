using Adohope.Modules.ManifestDb.Services;
using Adohope.Modules.VoiceNotes.Contexts;
using Adohope.Modules.VoiceNotes.Repositories;
using Adohope.Modules.VoiceNotes.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.VoiceNotes.Factories
{
    public class RecordingServiceFactory
    {
        public static RecordingService CreateRecordingService(string backupPath, MBFileService mbfileService = null)
        {
            var contextFactory = new VoiceNotesContextFactory(backupPath);
            var voiceNoteContext = contextFactory.CreateDbContext();
            var recordingRepository = new RecordingRepository(voiceNoteContext);
            return new RecordingService(recordingRepository, mbfileService);
        }
    }
}
