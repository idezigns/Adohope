using Adohope.Modules.ManifestDb.Enums;
using Adohope.Modules.ManifestDb.Models;
using Adohope.Shared.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Adohope.Modules.ManifestDb.Repos
{
    public class MbdbMBFileRepository : IMBFileRepository<IMBFile>
    {
        #region Constructors

        public MbdbMBFileRepository(string mbdbFilePath)
        {
            MbdbMBFiles = MbdbUtils.ProcessMBDBFile(Path.Combine(mbdbFilePath, "Manifest.mbdb"));
        }

        #endregion

        #region Properties

        protected Dictionary<long, MbdbMBFile> MbdbMBFiles;

        #endregion

        #region Interfaces

        public void Add(IMBFile entity)
        {
            // 1- decide what is the mbfile object size in mbdb file
            // 2- add the size number to the last element in MbdbFiles
            // 3- Add element..
            // NOTE: be carefull maybe there are aonther places where you have to change like the mbdb file size etc...
            throw new NotImplementedException();
        }

        public List<IMBFile> GetAll()
        {
            return MbdbMBFiles.Values.ToList<IMBFile>();
        }

        public List<IMBFile> GetAllByDomain(string domainName)
        {
            return MbdbMBFiles.Values.Where(f => f.Domain == domainName).ToList<IMBFile>();
        }

        public List<IMBFile> GetAllByFlag(FlagType mbFileFlag)
        {
            return MbdbMBFiles.Values.Where(f => f.Flags == mbFileFlag).ToList<IMBFile>();
        }

        public IMBFile GetByRelativePath(string relativePath)
        {
            return MbdbMBFiles.Values.Where(f => f.RelativePath == relativePath).FirstOrDefault();
        }

        public void Remove(IMBFile entity)
        {
            long key = MbdbMBFiles.FirstOrDefault(e => e.Value == entity).Key;

            if (MbdbMBFiles.ContainsKey(key))
                MbdbMBFiles.Remove(key);
        }

        #endregion
    }
}
