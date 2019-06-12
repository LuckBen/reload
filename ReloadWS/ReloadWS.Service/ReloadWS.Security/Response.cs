using System;
using System.Collections.Generic;

namespace ReloadWS.Security
{
	public class Response<T> :IResponse
	{
		public T contenido { get; set; }
	}
}
