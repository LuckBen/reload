using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.Security
{
	public class IResponse
	{
		public Estado estado;
		public HttpStatusCode httpResp { get; set; }
	}
}
