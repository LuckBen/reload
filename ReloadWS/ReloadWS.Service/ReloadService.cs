using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.ServiceModel;
using ReloadWS.DTO.Response;
using ReloadWS.DTO.Request;
using ReloadWS.BI;
using ReloadWS.DTO;

namespace ReloadWS.Service
{
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class ReloadService : IReloadService
	{
		public Response<UsuarioInfo> grabarInfo(Request<UsuarioInfo> info)
		{
			Response<UsuarioInfo> respuesta = new Response<UsuarioInfo>();

			BI.UsersModule.grabarInfo(info.usuario, info.contenido);

			return respuesta;
		}

		public Request<UsuarioInfo> obtenerInfo()
		{
			UsuarioInfo userinfo = new UsuarioInfo();
			userinfo.apellido = "benedict";
			userinfo.datosProfes = "Programador";
			userinfo.fechaNac = DateTime.Now;
			userinfo.habitos = "gym";
			userinfo.idiomas = "ingles";
			userinfo.nombre = "Luciano";
			userinfo.pais = new Pais
			{
				nombre = "Argentina",
				codigo = 1
			};
			userinfo.propiasPalabras = "blablabla";
			userinfo.sexo = "M";

			return new Request<UsuarioInfo>()
			{
				contenido = userinfo,
				token = "asdda",
				usuario = "Lucho"
			};
        }

		void IReloadService.salir(string username)
        {
			BI.UsersModule.usuariosConectados.quitarToken(username, BI.TokenModule.obtenerTokenCliente());
        }
    }
}
