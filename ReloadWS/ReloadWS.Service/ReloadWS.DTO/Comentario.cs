using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.DTO
{
    public class Comentario
    {
        public int nro { get; set; }
        public Sujeto emisor { get; set; }
        public Sujeto receptor { get; set; }
        public string contenido { get; set; }
        public int likes { get; set; }
        public int dislikes { get; set; }
        public bool debaja { get; set; }
        public bool esMensajePrivado { get; set; }
        public DateTime fecha { get; set; }

        public Comentario[] respuestas;
    }
}
