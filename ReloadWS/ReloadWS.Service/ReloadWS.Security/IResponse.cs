using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.Security
{
	public interface IResponse
	{
        Estado estado { get; set; }
        HttpStatusCode httpResp { get; set; }

        string extra { get; set; }
	}
}
