﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.DTO
{
    public class UsuarioConectado
    {
        public Sujeto usuario { get; set; }
        public List<string> tokens { get; set; }
        public DateTime emisionToken { get; set; }
		
		public UsuarioConectado()
		{
			tokens = new List<string>();
			usuario = new Sujeto();
        }	

    }
}
