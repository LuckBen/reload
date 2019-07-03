using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.DTO
{
    public class Post
    {
        public string _id { get; set; }
        public Sujeto propietario { get; set; }
        public string titulo { get; set; }
        public string imagen { get; set; }
        public string contenido { get; set; }
        public Categoria categoria { get; set; }
        public List<string> tags { get; set; }
        public int puntos { get; set; }
        public bool sticky { get; set; }
        public int visitas { get; set; }
        public int seguidores { get; set; }
        public int favoritos { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime fechaModificacion { get; set; }

        public List<Comentario> comentarios;

        public bool seComenta { get; set; }

        public string etiquetas { get; set; }
		public bool activo { get; set; }
		
		public Post()
		{
			comentarios = new List<Comentario>();
			categoria = new Categoria();
			propietario = new Sujeto();
			tags = new List<string>();
        }

	}
}
