using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.DTO.Response
{
	public interface IResponse
	{
        Estado estado { get; set; }

        string extra { get; set; }
	}
}
