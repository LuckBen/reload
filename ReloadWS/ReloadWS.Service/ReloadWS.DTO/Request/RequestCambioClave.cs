using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.DTO.Request
{
    public class RequestCambioClave
    {
        public string claveActual { get; set; }
        public string claveNueva { get; set; }
    }
}
