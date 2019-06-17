using System;
using System.Collections.Generic;
using System.Net;

namespace ReloadWS.DTO.Response
{
	public class Response<T> :IResponse
	{
        private Estado _estado;
        private string _extra;
		public T contenido { get; set; }

        public Estado estado
        {
            get
            {
                return _estado;
            }

            set
            {
                _estado = value;
            }
        }

        public string extra
        {
            get
            {
                return _extra;
            }

            set
            {
                _extra = value;
            }
        }

    }
}
