using Adohope.Modules.Contacts.Factories;
using Adohope.Modules.Contacts.Services;
using Adohope.Modules.ManifestDb.Factories;
using Adohope.Modules.Messages.Factories;
using Adohope.Modules.Messages.Services;
using Adohope.Modules.Notes.Factories;
using Adohope.Modules.Notes.Services;
using Adohope.Modules.Photos.Factories;
using Adohope.Modules.Photos.Services;
using Adohope.Modules.VoiceNotes.Factories;
using Adohope.Modules.VoiceNotes.Services;
using Adohope.Shared.PList;
using System;
using System.IO;

namespace Adohope
{
    public class Backup : IBackup
    {
        #region Constructors

        public Backup(string backupPath)
        {
            _backupPath = backupPath;
        }

        #endregion

        #region Properties

        public string BackupPath { get => _backupPath; }

        #endregion

        #region Fields

        protected string _backupPath;
        protected DynamicPList _info;
        protected DynamicPList _status;
        protected AssetService _assetService;
        protected RecordingService _voiceNoteService;
        protected ChatService _chatService;
        protected PersonService _personService;
        protected NoteService _noteService;

        #endregion

        #region Methods

        #region PList Files

        public dynamic Info()
        {
            return _info ?? (_info = new DynamicPList(Path.Combine(BackupPath, "Info.plist")));
        }

        public dynamic Status()
        {
            return _status ?? (_status = new DynamicPList(Path.Combine(BackupPath, "Status.plist")));
        }

        #endregion

        #region Services

        public AssetService GetAssetService()
        {
            if (_assetService == null)
            {
                var manifestContext = MBFileServiceFactory.CreateMBFileService(this);

                Version productVersion = new Version(Info().ProductVersion);

                _assetService = AssetServiceFactory.CreateAssetService(
                    BackupPath
                    , productVersion
                    , manifestContext);
            }

            return _assetService;
        }

        public RecordingService GetRecordingService()
        {
            if (_voiceNoteService == null)
            {
                var mbfileService = MBFileServiceFactory.CreateMBFileService(this);

                _voiceNoteService = RecordingServiceFactory.CreateRecordingService(BackupPath, mbfileService);
            }
            return _voiceNoteService;
        }

        public ChatService GetChatService()
        {
            if (_chatService == null)
            {
                _chatService = ChatServiceFactory.CreateService(BackupPath);
            }

            return _chatService;
        }

        public PersonService GetPersonService()
        {
            if (_personService == null)
            {
                _personService = PersonServiceFactory.CreateService(BackupPath);
            }

            return _personService;
        }

        public NoteService GetNoteService()
        {
            if (_noteService == null)
            {
                _noteService = NoteServiceFactory.CreateService(BackupPath);
            }

            return _noteService;
        }

        #endregion

        //public bool IsCompleted()
        //{
        //    return StatusPList.BackupState != "empty" && StatusPList.SnapshotState == "finished";
        //}

        #endregion
    }
}
