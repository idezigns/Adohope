using Adohope.Modules.Messages.Enums;
using PListNet.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adohope.Modules.Messages.Models
{
    public class Chat
    {
        protected DateTime _lastReadMessageTimestamp;

        public long ID { get; set; }
        //public byte[] Properties { get; set; }
        public dynamic Properties { get; set; } // DictionaryNode
        //public string ChatIdentifier { get; set; } //can be found in handle table -> (id) column!
        public ChatService ServiceType { get; set; } // service_name: iMessage - SMS
        public AccountLogin AccountLogin { get; set; } // E:xxx - P:+966xxx obj
        public bool IsArchived { get; set; } // 0-1

        // ---------------------------------------------------------------------------------------
        //DateTime.Parse(data, CultureInfo.InvariantCulture);
        //Value.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.ffffffZ");
        //DateTime
        // ---------------------------------------------------------------------------------------
        // todo: NOTE: some versions has no LastReadMessageTimestamp field in the database table!
        // SO, if you want to use this property try to figure out whether the property is exists 
        // in database or not? ... If the propety exists then simply return the value, if not,
        // then read last message in the chat and get the date_read property from it and return it
        // as the LastReadMessageTimestamp.
        // ---------------------------------------------------------------------------------------
        public DateTime LastReadMessageTimestamp
        {
            get
            {
                if (_lastReadMessageTimestamp == null) // property last_read_message_timestamp is not exists in the database table!
                {
                    var lastMessage = ChatMessageJoins.OrderByDescending(p => p.Message.ID).FirstOrDefault()?.Message;
                    
                    if(lastMessage != null)
                        _lastReadMessageTimestamp = lastMessage.Date_Read;
                }

                return _lastReadMessageTimestamp;
            }
            set
            {
                _lastReadMessageTimestamp = value;
            }
        }
        //public Handle Handle { get; set; }
        //public List<Message> Messages { get; set; }
        public List<ChatMessageJoin> ChatMessageJoins { get; set; }
        public List<ChatHandleJoin> ChatHandleJoin { get; set; }
    }
}
