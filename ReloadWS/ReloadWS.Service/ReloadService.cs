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
namespace ReloadWS.Service
{
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class ReloadService : IReloadService
	{
        public Security.Response<DTO.Usuario> registro(RegistroRequest registroRequest)
        {
			Security.Response<DTO.Usuario> respuesta = new Security.Response<DTO.Usuario>();

			BI.UsersModule.Registro(registroRequest);

			respuesta.estado = BI.UsersModule.estado;
			respuesta.httpResp = Helper.obtenerCodigoEstadoHttp(BI.UsersModule.estado);

			if (!respuesta.estado.hayError)
			{
				Helper.enviarMailActivacionMail(registroRequest.mail);
			}

			return respuesta;
        }

		Security.Response<DTO.Usuario> IReloadService.logeo(LoginRequest loginRquest)
		{
			Security.Response<DTO.Usuario> respuesta = new Security.Response<DTO.Usuario>();
			return respuesta;
		}
		public string verificarMail(string mail)
		{
			BI.UsersModule.verificarMail(mail);

			return "mail verificado con exito";
		}

	}
}
