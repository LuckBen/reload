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
    public class AuthenticationService : IAuthenticationService
	{
        DTO.Response.Response<DTO.Usuario> IAuthenticationService.register(RegistroRequest registroRequest)
        {
            if(registroRequest == null)
            {
                return null;
            }


            DTO.Response.Response<DTO.Usuario> respuesta = new DTO.Response.Response<DTO.Usuario>();

            BI.UsersModule.Registro(registroRequest);

            respuesta.estado = BI.UsersModule.estado;

      
            if (!respuesta.estado.hayError)
            {
                Helper.enviarMailActivacionMail(registroRequest.mail);
            }
            

            return respuesta;
        }

		DTO.Response.Response<DTO.Usuario> IAuthenticationService.login(LoginRequest loginRquest)
        {
            DTO.Response.Response<DTO.Usuario> respuesta = new DTO.Response.Response<DTO.Usuario>();

            respuesta = BI.UsersModule.Logeo(loginRquest);
            respuesta.estado = BI.UsersModule.estado;

            return respuesta;

        }
        string IAuthenticationService.verificarMail(string mail)
        {
            if(mail == null)
            {
                return null;
            }

            

            BI.UsersModule.verificarMail(mail);

            return "mail verificado con exito";
        }

        public Pais[] obtenerInfoRequest()
        {
            

            List<Pais> listapais = new List<Pais>();
            listapais.Add(new Pais
            {
                codigo = "AR",
                nombre = "Argentina"
            });

            listapais.Add(new Pais
            {
                codigo = "AL",
                nombre = "Alemania"
            });
            return listapais.ToArray();
        }

		public DTO.Response.Response<Captcha> getCaptcha()
		{
            

            DTO.Response.Response<DTO.Captcha> respuesta = new DTO.Response.Response<DTO.Captcha>();
			respuesta.contenido = BI.CaptchaModule.getRandom();
			respuesta.estado = BI.CaptchaModule.estado;

			return respuesta;
		}

        public void insertarPaises()
        {
      

            

            BI.PaisesModule.insertarPaises();
        }

        DTO.Response.Response<DTO.Usuario> IAuthenticationService.obtenerUsuario(Request<string> obtenerUsuarioRequest)
        {
            if (obtenerUsuarioRequest == null)
            {
                return null;
            }
            

            Response<Usuario> respuesta = new Response<Usuario>();
            respuesta.contenido = BI.UsersModule.obtenerUsuario(obtenerUsuarioRequest);
            respuesta.estado = UsersModule.estado;
            return respuesta;
        }


        public string hola()
        {
            

            return "hola";
        }

    }
}
