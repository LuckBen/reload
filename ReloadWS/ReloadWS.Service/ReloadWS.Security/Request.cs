using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.Security
{
    public class Request<T> : IRequest
    {
        private string _token;
        private string _usuario;
        public T contenido { get; set; }
        public string token
        {
            get
            {
                return _token;
            }

            set
            {
                _token = value;
            }
        }
        public string usuario
        {
            get
            {
                return _usuario;
            }

            set
            {
                _usuario = value;
            }
        }
    }
}
