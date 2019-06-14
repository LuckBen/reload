using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.DTO
{
	public class PostDestacado
	{
		public enum TIPO_DESTAQUE { PUNTOS, COMENTARIO, RECIENTE };
		public TIPO_DESTAQUE destaque { get; set; }
		public Post post { get; set; }

	}
}
