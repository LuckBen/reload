using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.DTO
{
	[Serializable]
	public class InvalidDataException:Exception
	{
		public InvalidDataException()
		{

		}

		public InvalidDataException(string descrp) : base(descrp) { }
	}
}
