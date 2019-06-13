using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.DTO
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

        public void capturarError(Exception ex, bool internalError)
        {
            this.mensaje = (internalError ? "Ocurrió un error inesperado" : ex.Message);
            this.hayError = true;
			this.internalError = internalError;

            if (internalError)
            {
             //   Logs.grabar(new Exception(ex.Message));
            }
        }
    }
}
