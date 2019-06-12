using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.DAL
{
    public abstract class Servicio
    {
        public Estado estado { get; set; }
        public Servicio()
        {
            estado = new Estado();
        }
    }
}
