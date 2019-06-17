using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.DTO.Request
{
    [DataContract]
    public class RegistroRequest
    {
        [DataMember]
        public string usuario { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string mail { get; set; }
    }
}
