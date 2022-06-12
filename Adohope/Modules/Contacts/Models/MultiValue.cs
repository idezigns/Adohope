using Adohope.Modules.Contacts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Contacts.Models
{
    public class MultiValue
    {
        public long UID { get; set; }
        public long Record_ID { get; set; }
        public PropertyType Property { get; set; }
        public long Identifier { get; set; }
        public LabelType Label { get; set; }
        public string Value { get; set; }
        public string Guid { get; set; }

        public Person Person { get; set; }
    }
}
