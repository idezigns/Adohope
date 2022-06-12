using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Messages.Models
{
    public class ChatMessageJoin
    {
        public long Chat_ID { get; set; }
        public long Message_Id { get; set; }
        //todo: convert to DateTime
        // older versions has no field called Message_Date (Seen on version 8.*)
        public long? Message_Date { get; set; } 

        public Chat Chat { get; set; }
        public Message Message { get; set; }
    }
}
