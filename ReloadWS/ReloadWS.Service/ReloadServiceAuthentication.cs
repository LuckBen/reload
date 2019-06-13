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
    public class ReloadServiceAuthentication : IReloadAuthentication
    {
        DTO.Response.Response<DTO.Usuario> IReloadAuthentication.registro(RegistroRequest registroRequest)
        {
			DTO.Response.Response<DTO.Usuario> respuesta = new DTO.Response.Response<DTO.Usuario>();

            BI.UsersModule.Registro(registroRequest);

            respuesta.estado = BI.UsersModule.estado;
            respuesta.httpResp = Helper.obtenerCodigoEstadoHttp(BI.UsersModule.estado);

            if (!respuesta.estado.hayError)
            {
                Helper.enviarMailActivacionMail(registroRequest.mail);
            }

            return respuesta;
        }

		DTO.Response.Response<DTO.Usuario> IReloadAuthentication.logeo(LoginRequest loginRquest)
        {
			DTO.Response.Response<DTO.Usuario> respuesta = new DTO.Response.Response<DTO.Usuario>();

            respuesta = BI.UsersModule.Logeo(loginRquest);
            respuesta.estado = BI.UsersModule.estado;
            respuesta.httpResp = Helper.obtenerCodigoEstadoHttp(respuesta.estado);

            return respuesta;

        }
        string IReloadAuthentication.verificarMail(string mail)
        {
            BI.UsersModule.verificarMail(mail);

            return "mail verificado con exito";
        }

        public RegistroRequest obtenerInfoRequest()
        {
            return new RegistroRequest
            {
                mail = "benedict.luciano@gmail.com",
                password = "xddxxd",
                usuario = "lucho"
            };
        }

		public DTO.Response.Response<Captcha> obtenerCaptcha()
		{
			DTO.Response.Response<DTO.Captcha> respuesta = new DTO.Response.Response<DTO.Captcha>();
			respuesta.contenido = BI.CaptchaModule.getRandom();
			respuesta.estado = BI.CaptchaModule.estado;
			respuesta.httpResp = Helper.obtenerCodigoEstadoHttp(respuesta.estado);

			return respuesta;
		}
	}
}
