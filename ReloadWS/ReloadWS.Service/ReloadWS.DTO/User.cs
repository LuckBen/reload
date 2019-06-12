using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.DTO
{
    public class Usuario
    {

        public string codigo { get; set; }
        public string password { get; set; }
        public int puntos { get; set; }
        public Rango rango { get; set; }
        public UsuarioInfo info { get; set; }
        public Medalla[] medallas { get; set; }
        public Post[] publicaciones { get; set; }
        public Post[] posts { get; set; }
        public Sujeto[] seguidores { get; set; }
        public Sujeto[] siguiendo { get; set; }
        public Comentario[] mensajes { get; set; }
    }

    public class UsuarioInfo
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Pais pais { get; set; }
        public string sexo { get; set; }
        public DateTime fechaNac { get; set; }
        public string idiomas { get; set; }
        public string datosProfes { get; set; }
        public string habitos { get; set; }
        public string propiasPalabras { get; set; }
    }
}
