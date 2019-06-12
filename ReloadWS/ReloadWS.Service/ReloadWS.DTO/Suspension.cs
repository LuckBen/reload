using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.DTO
{
	public class Suspension
	{
		public bool suspendido { get; set; }
		public string razon { get; set; }
		public DateTime fechaInicio { get; set; }
		public DateTime fechaHasta { get; set; }
	}
}
