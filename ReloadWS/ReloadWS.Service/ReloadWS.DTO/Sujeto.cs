using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.DTO
{
    public class Sujeto
    {
		public int id { get; set; }
        public string codigo { get; set; }
        public string alias { get; set; }
        public string imagen { get; set; }
        public Rango rango { get; set; }
        public Pais pais { get; set; }
        public int nroComentarios { get; set; }
		
		public Sujeto()
		{
			rango = new Rango();
			pais = new Pais();
		}
    }
}
