using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.DTO
{
	public class Captcha
	{
		public string id { get; set; }
		public string captcha { get; set; }
		public string respuesta { get; set; }
	}
}
