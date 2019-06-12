using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.DAL
{
    public class Estado
    {
        public string mensaje { get; set; }
        public string observacion { get; set; }
        public bool hayError { get; set; }
        public Exception exepcion { get; set; }

        public void iniciar()
        {
            this.mensaje = null;
            this.observacion = null;
            this.hayError = false;
            this.exepcion = null;
        }
        public Estado()
        {
        }

        public void capturarError(Exception ex, string observacion)
        {
            this.mensaje = ex.Message;
            this.observacion = observacion;
            this.hayError = true;
            this.exepcion = ex;
        }
    }
}
