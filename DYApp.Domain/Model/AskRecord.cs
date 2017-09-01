using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.Domain.Model
{
    public class AskRecord : AggregateRoot
    {
        public DateTime BetweenBegin { get; set; }
        public DateTime BetweenEnd { get; set; }
        public int Times { get; set; }
        public string Place { get; set; }
        public string Asker1 { get; set; }
        public string Asker2 { get; set; }               
        public virtual Involved Involved { get; set; }
        public string Department { get; set; }
        public string Certificates1 { get; set; }
        public string Certificates2 { get; set; }
        public string AskContent { get; set; }
        public string AnswerContent { get; set; }
        public string Asker1Sign { get; set; }
        public string Asker2Sign { get; set; }
        public string AskerSignTime { get; set; }
        public string InvolvedSign { get; set; }
        public string InvolvedSignTime { get; set; }
    }
}
