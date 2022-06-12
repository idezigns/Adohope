using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Messages.Models
{
    public class Handle
    {
        public long ID { get; set; }
        public string HandlerID { get; set; }
        //public string Country { get; set; } //sa
        //public string Service { get; set; }
        public string UncanonicalizedID { get; set; }
        //public string PersonCentricID { get; set; }
        //public List<Chat> Chats { get; set; }
        public List<ChatHandleJoin> ChatHandleJoins { get; set; }
    }
}
