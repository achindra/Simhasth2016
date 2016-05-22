using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SimhastControlPanel
{
    [DataContract(Name = "SMS")]
    class SMSMessage
    {
        [DataMember(Name ="Number")]
        public string MobileNumber { get; set; }

        [DataMember(Name ="Message")]
        public string Message { get; set; }

        public SMSMessage()
        {

        }

        public SMSMessage(string number, string message)
        {
            MobileNumber = number;
            Message = message;
        }
    }
}
