using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Adohope.Shared.Utils
{
    public class PathUtils
    {
        public static string MBFilePath(string backupPath, string mBFileName)
        {
            return BackupCheckUtils.AreFilesOrganizedInSubFolders(backupPath)

                ? Path.Combine(
                        backupPath
                        , mBFileName.Substring(0, 2)
                        , mBFileName
                    )

                : Path.Combine(backupPath, mBFileName);
        }

        public static string ManifestFilePath(string backupPath, string fileName)
        {
            return Path.Combine(backupPath, fileName);
        }
    }
}
