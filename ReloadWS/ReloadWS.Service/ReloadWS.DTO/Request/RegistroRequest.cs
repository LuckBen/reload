using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.DTO.Request
{
    public class RegistroRequest
    {
        public string usuario { get; set; }
        public string password { get; set; }
        public string mail { get; set; }
    }
}
