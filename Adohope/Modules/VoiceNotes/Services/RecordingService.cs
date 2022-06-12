using Adohope.Modules.ManifestDb.Models;
using Adohope.Modules.ManifestDb.Services;
using Adohope.Modules.VoiceNotes.Models;
using Adohope.Modules.VoiceNotes.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.VoiceNotes.Services
{
    public class RecordingService
    {
        #region Constructors

        public RecordingService(IRecordingRepository recordingRepository, MBFileService mbfileService = null)
        {
            RecordingRepository = recordingRepository;
            MBFileService = mbfileService;
        }

        #endregion

        #region Properties

        public IRecordingRepository RecordingRepository { get; }
        public MBFileService MBFileService { get; }

        #endregion

        #region Methods

        public List<Recording> GetAllRecordings()
        {
            var recordings = RecordingRepository.GetAll();

            if (MBFileService == null) return recordings;

            foreach (Recording recording in recordings)
            {
                recording.MBFile = (MBFile)MBFileService.GetByRelativePath(recording.RelativePath);
            }

            return recordings;
        }

        #endregion

    }
}
