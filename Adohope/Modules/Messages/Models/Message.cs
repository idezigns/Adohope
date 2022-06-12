using System;
using System.Collections.Generic;

namespace Adohope.Modules.Messages.Models
{
    public class Message
    {
        public long ID { get; set; }
        public string Text { get; set; }
        //public Handle Handle { get; set; }
        public List<ChatMessageJoin> ChatMessageJoins { get; set; }
        //public Chat Chat { get; set; }
        public DateTime Date { get; set; }
        public DateTime Date_Read { get; set; }
        //public DateTime DateDelivered { get; set; }
        //public bool IsDelivered { get; set; }
        //public bool IsFinished { get; set; }
        //public bool IsEmote { get; set; }
        //public bool IsFromMe { get; set; }
        //public bool IsEmpty { get; set; }
        //public bool IsRead { get; set; }

        //public bool IsSent { get; set; }
        //public bool IsAudioMessage { get; set; }
        //public bool IsPlayed { get; set; }
        //public DateTime DatePlayed { get; set; }
        ////public DateTime DateDateTime { get; set; }
        ////public DateTime DateTimeRead { get; set; }
        ////public DateTime DateTimeDelivered { get; set; }
        ////public DateTime DateTimePlayed { get; set; }

        ////item_type
        ////other_handle
        ////share_status
        ////share_direction
        ////is_expirable
        ////expire_state
        ////destination_caller_id << maybe the receiver phone number(my phone number)
        ////is_corrupt
        ////is_spam
        ////service SMS-iMessage
        ////public string Service { get; set; }
        ////account p:+966333 << starts with small p or capital P << 
        ////public string Account { get; set; }
        ////error 0|1
        ////public long Error { get; set; }
        ////is_service_message
        ////is_forward
        ////is_archive
        ////is_system_message
        ////id_delayed
        ////is_auto_reply
        ////is_prepared
    }
}
