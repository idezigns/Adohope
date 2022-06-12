using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Contacts.Models
{
    public class Person
    {
        public long RowID { get; set; }
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }

        public List<MultiValue> MultiValues { get; set; }
    }
}
