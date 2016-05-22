using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SimhastControlPanel
{
    [DataContract(Name = "SMS")]
    public class Item
    {
        [DataMember(Name = "phoneno")]
        public string phoneno { get; set; }

        [DataMember(Name = "messageval")]
        public string messageval { get; set; }
    }
}
