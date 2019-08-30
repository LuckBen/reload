using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.DTO
{
    public class Rango
    {
        public int id { get; set; }

        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
        public int puntosRequeridos { get; set; }
        public int puntosDar { get; set; }

    }
}
