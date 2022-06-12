using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Messages.Models
{
    public class ChatHandleJoin
    {
        public long Chat_ID { get; set; }
        public long Handle_ID { get; set; }

        public Chat Chat { get; set; }
        public Handle Handle { get; set; }
    }
}
