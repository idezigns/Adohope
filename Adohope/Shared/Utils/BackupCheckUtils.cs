using Adohope.Shared.PList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Adohope.Shared.Utils
{
    public static class BackupCheckUtils
    {
        #region Properties

        public static object StatusPlist { get; private set; }

        #endregion

        #region Utils

        public static bool IsBackupFolder(string path)
        {
            /**
             *      To Detect whether the backup is completed or not
             *      
             * Completed and uncompleted backups will contain Status.plist file, where there are
             * two fields that tells the status of the backup whether the backup is completed or not,
             * they are BackupState and SnapshotState. Also, uncompleted backup will contain a folder
             * called Snapshot.
             * ---------------------------------------------------------------------------------------*/

            return File.Exists(PathUtils.ManifestFilePath(path, "Status.plist"))
                    && (File.Exists(PathUtils.ManifestFilePath(path, "Manifest.db"))
                        || File.Exists(PathUtils.ManifestFilePath(path, "Manifest.mbdb")));
        }

        public static bool AreFilesOrganizedInSubFolders(string backupPath)
        {
            try
            {
                dynamic statusPList = new DynamicPList(PathUtils.ManifestFilePath(backupPath, "Status.plist"));

                // For version 2.4 (seen on iOS 9 Devices) | All of the files are contained in the same directory
                return double.Parse(statusPList.Version) >= 3.2;
            }
            catch (Exception)
            {
                //if Status.plist not exists, then try to make a guess
                //Explain the guessing process:
                //
                // 1- Get all folders in the backup folder
                // 2- Loop throw the folders until you get a folder with two character name
                // 3- Loop throw all the files inside to make sure they all start with the same 
                // folder two characters!
                //
                // Note:
                // If one folder found and matched the condition then return true.
                //
                // =============================================================================
                string[] folders = Directory.GetDirectories(backupPath);
                bool foundFolderWithAllFilesStartWithFolderName = false;

                for (int i = 0; i < folders.Length; i++)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(folders[i]);

                    if (dirInfo.Name.Length == 2)
                    {
                        string[] files = Directory.GetFiles(dirInfo.FullName);

                        //if folder has no files then we will say it's not a correct backup folder!
                        //else, we will assume it is a correct backup folder until we see something else..
                        bool allFilesStartWithFolderName = files.Length > 0;

                        foreach (string f in files)
                        {
                            if (f.Substring(0, 2).Equals(dirInfo.Name))
                            {
                                allFilesStartWithFolderName = false;
                                break;
                            }
                        }

                        if (allFilesStartWithFolderName)
                            foundFolderWithAllFilesStartWithFolderName = true;
                    }

                    if (foundFolderWithAllFilesStartWithFolderName)
                        return true;
                }
            }

            return false;
        }

        //todo: not tested
        public static bool IsBackupProcessCompleted(Backup backup)
        {
            return backup.Status().BackupState != "empty"
                && backup.Status().SnapshotState == "finished";
        }

        #endregion
    }
}
