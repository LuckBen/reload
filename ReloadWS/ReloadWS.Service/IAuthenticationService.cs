using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using ReloadWS.DTO.Response;
using ReloadWS.DTO.Request;

namespace ReloadWS.Service
{
    [ServiceContract]
    public interface IAuthenticationService
    {
        [OperationContract]
        [WebInvoke(Method = "*",
                    BodyStyle = WebMessageBodyStyle.Bare,
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "login")]
        DTO.Response.Response<DTO.Usuario> login(LoginRequest loginRquest);

        [OperationContract]
        [WebInvoke(Method = "*",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        DTO.Response.Response<DTO.Usuario> register(RegistroRequest registroRequest);

        [OperationContract]
        [WebInvoke(Method = "*",
                    BodyStyle = WebMessageBodyStyle.Bare,
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "verificar-mail/{mail}")]
        string verificarMail(string mail);

        [OperationContract]
        [WebInvoke(Method = "*",
                    BodyStyle = WebMessageBodyStyle.Bare,
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "getCaptcha")]
        Response<DTO.Captcha> getCaptcha();

        [OperationContract]
        [WebInvoke(Method = "*",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare)]
        DTO.Response.Response<DTO.Usuario> obtenerUsuario(Request<string> obtenerUsuario);


        [OperationContract]
        [WebInvoke(Method = "*",
                    BodyStyle = WebMessageBodyStyle.Bare,
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "obtenerInfoRequest")]
        DTO.Pais[] obtenerInfoRequest();

        [OperationContract]
        [WebInvoke(Method = "*",
                    BodyStyle = WebMessageBodyStyle.Bare,
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "insertarPaises")]
        void insertarPaises();

    

        [OperationContract]
        [WebInvoke(Method = "*", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
            UriTemplate = "hola")]
        string hola();

    }
}
