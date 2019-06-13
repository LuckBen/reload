using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.Security
{
    public interface IRequest
    {
        string usuario { get; set; }
        string token { get; set; }
    }
}
