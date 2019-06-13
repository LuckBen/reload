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
using ReloadWS.Security;

namespace ReloadWS.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ReloadServiceAuthentication : IReloadAuthentication
    {
        Security.Response<DTO.Usuario> IReloadAuthentication.registro(RegistroRequest registroRequest)
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

        Security.Response<DTO.Usuario> IReloadAuthentication.logeo(LoginRequest loginRquest)
        {
            Security.Response<DTO.Usuario> respuesta = new Security.Response<DTO.Usuario>();

            respuesta.contenido = BI.UsersModule.Logeo(loginRquest);
            respuesta.estado = BI.UsersModule.estado;
            respuesta.httpResp = Helper.obtenerCodigoEstadoHttp(respuesta.estado);

            if (!respuesta.estado.hayError)
            {
                respuesta.extra = TokenGenerator.GenerateToken(loginRquest.login);
            }

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
    }
}
