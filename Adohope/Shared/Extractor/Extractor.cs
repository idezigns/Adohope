using Adohope.Modules.Contacts.Models;
using Adohope.Modules.Messages.Models;
using Adohope.Modules.Notes.Models;
using Adohope.Modules.Photos.Models;
using Adohope.Modules.VoiceNotes.Models;
using Adohope.Shared.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ImageMagick;
using System.Diagnostics;

namespace Adohope.Shared.Extractor
{
    public class Extractor
    {
        

        public string DestinationPath { get; protected set; }

        public string UniqueDestinationPath { get; protected set; }

        public Backup Backup { get; protected set; }

        public Extractor(Backup backup, string destinationPath)
        {
            Backup = backup;
            DestinationPath = destinationPath;
            UniqueDestinationPath = Path.Combine(DestinationPath, Guid.NewGuid().ToString());
        }

        public void CreateUniqueFolderForTheExportedData()
        {
            Directory.CreateDirectory(UniqueDestinationPath);
        }

        public void ExtractNotes(List<Note> notes)
        {
            string desPath = Path.Combine(UniqueDestinationPath, "Notes");

            Directory.CreateDirectory(desPath);

            foreach(Note note in notes)
            {
                string filePath = Path.Combine(desPath, $"{note.ZNOTE}.txt");
                File.WriteAllText(filePath, note.ZDATA);
            }
        }

        public void ExtractVoiceNotes(List<Recording> voiceNotes)
        {
            string desPath = Path.Combine(UniqueDestinationPath, "VoiceNotes");

            Directory.CreateDirectory(desPath);

            foreach (Recording recording in voiceNotes)
            {
                if (recording.Duration.TotalSeconds < 0) // some recordings has no data, it comes with (-1) seconds!, so they don't have a physical file
                    continue;

                string filePath = Path.Combine(desPath, $"{recording.Label}.mp4");
                //File.WriteAllText(filePath, note.ZDATA);

                if (recording.MBFile == null)
                    continue;

                File.Copy(PathUtils.MBFilePath(Backup.BackupPath, recording.MBFile.FileID)
                    , filePath);
            }
        }

        public void ExtractPhotosAndVideos(List<Asset> assets, bool HEICconvert = false)
        {
            string desPath = Path.Combine(UniqueDestinationPath, "Assets");

            Directory.CreateDirectory(desPath);

            int i = 1;
            foreach (Asset asset in assets)
            {
                // iPad wallpapers has no file name and directory but has a UUID and ZIMAGEURLDATA and ZTHUMBNAILURLDATA
                //var fileName = asset.FileName ?? (asset.ZUUID + ".png");
                if (asset.FileName == null) continue; // file is in the device only, not backed up. (I guess :/)

                //todo: bug: some photos (seen in screenshot) has no MBFile record!
                if (asset.MBFile == null) continue;

                string filePath = Path.Combine(desPath, asset.FileName);
                //File.WriteAllText(filePath, note.ZDATA);

                UpdateStatusBarMessage.ShowStatusMessage("(" + i + " of " + assets.Count + ") - Saving " + filePath);
          
                i++;

                // TODO: if file exists, ask to overwrite
                if (!File.Exists(filePath))
                {
                    
                    if (HEICconvert && Path.GetExtension(asset.FileName).ToLower().Contains("heic"))
                    {
                        using (MagickImage image = new MagickImage(PathUtils.MBFilePath(Backup.BackupPath, asset.MBFile.FileID)))
                        {
                            string newFile = Path.Combine(desPath, Path.ChangeExtension(asset.FileName, ".jpg"));
                            //image.Write(newFile);
                        }
                    } else
                    {
                        //File.Copy(PathUtils.MBFilePath(Backup.BackupPath, asset.MBFile.FileID), filePath);
                    }
                     
                }
                    
            }
        }

        public void ExtractContacts(List<Person> contacts)
        {
            string desPath = Path.Combine(UniqueDestinationPath, "Contacts");

            Directory.CreateDirectory(desPath);
            StringBuilder sb = new StringBuilder();

            foreach (Person person in contacts)
            {
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine($"RowID : {person.RowID}");
                sb.AppendLine($"First : {person.First}");
                sb.AppendLine($"Middle : {person.Middle}");
                sb.AppendLine($"Last : {person.Last}");

                if (person.MultiValues.Count == 0) continue;

                sb.AppendLine();
                sb.AppendLine("** Extra Values **");
                sb.AppendLine("- - - - - - - - - - - - - - -");

                foreach (var value in person.MultiValues)
                {
                    sb.AppendLine();
                    sb.AppendLine($"UID : {value.UID}");
                    sb.AppendLine($"Label : {value.Label.ToString()}");
                    sb.AppendLine($"Value : {value.Value}");
                }

                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine("=============================");
            }

            string outputFilePath = Path.Combine(desPath, "Contacts.txt");
            File.WriteAllText(outputFilePath, sb.ToString());
        }

        public void ExtractChats(List<Chat> chats)
        {
            string desPath = Path.Combine(UniqueDestinationPath, "Messages");

            Directory.CreateDirectory(desPath);

            foreach (Chat chat in chats)
            {
                StringBuilder sb = new StringBuilder();

                // chat information
                sb.AppendLine($"ID : {chat.ID}");
                sb.AppendLine($"Account Login : {chat.AccountLogin}");
                sb.AppendLine($"Handler ID : {chat.ChatHandleJoin[0].Handle.HandlerID}");
                sb.AppendLine($"Handler : {chat.ChatHandleJoin[0].Handle.UncanonicalizedID}");
                sb.AppendLine($"Is archived : {chat.IsArchived}");
                sb.AppendLine($"Is chat opened? : " + (chat.LastReadMessageTimestamp.Ticks > 0 ? "YES" : "NO"));
                sb.AppendLine($"Last Read Message : {chat.LastReadMessageTimestamp}");
                sb.AppendLine($"Service Type : {chat.ServiceType}");
                sb.AppendLine($"Properties : [NotImplemented]");

                // messages
                foreach (ChatMessageJoin chatMessageJoin in chat.ChatMessageJoins)
                {
                    // separator
                    sb.AppendLine();
                    sb.AppendLine();
                    sb.AppendLine("=============================");
                    sb.AppendLine();
                    sb.AppendLine();

                    // message
                    sb.AppendLine($"ID : {chatMessageJoin.Message.ID}");
                    sb.AppendLine($"Text : {chatMessageJoin.Message.Text}");
                }

                string outputFilePath = Path.Combine(desPath, $"{chat.ChatHandleJoin[0].Handle.HandlerID}.txt");
                File.WriteAllText(outputFilePath, sb.ToString());
            }
        }
    }
}
