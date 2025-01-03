using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ComplexTypes
{
    public class EmailThread
    {
        public List<EmailData> Data { get; set; }
    }
    public class EmailData
    {
        public string Summary { get; set; }
        public string CreatedTime { get; set; }
        public Author Author { get; set; }
        public string FromEmailAddress { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }
    }
}
