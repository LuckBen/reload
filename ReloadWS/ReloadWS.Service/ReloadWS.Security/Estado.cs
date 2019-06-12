using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.Security
{
    public class Estado
    {
        public string mensaje { get; set; }
        public bool hayError { get; set; }
		public bool internalError { get; set; }

        public void iniciar()
        {
            this.mensaje = null;
            this.hayError = false;
        }
        public Estado()
        {
        }

        public void capturarError(string mensajeEx, bool internalError)
        {
            this.mensaje = mensajeEx;
            this.hayError = true;
			this.internalError = internalError;
        }
    }
}
