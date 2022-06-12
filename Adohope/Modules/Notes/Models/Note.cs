using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Notes.Models
{
    public class Note
    {
        //public int NoteDataID { get; set; }
        //public int NoteID { get; set; }
        //public byte[] Data { get; set; }
        //public bool IsPasswordProtected { get; set; }
        public long Z_PK { get; set; }
        public long ZNOTE { get; set; } // Primary key located in Z_PRIMARYKEY table
        public string ZDATA { get; set; }
    }
}
